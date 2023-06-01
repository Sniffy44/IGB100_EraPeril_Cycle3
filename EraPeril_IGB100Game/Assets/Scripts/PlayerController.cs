using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public Camera camera;

    [Header("Configurations")]
    public float walkSpeed;
    public float runSpeed;
    public float jumpSpeed;

    [Header("Camera Effects")]
    public float baseCameraFov = 60f;
    public float baseCameraHeight = .85f;

    public float walkBobbingRate = .75f;
    public float runBobbingRate = 1f;
    public float maxWalkBobbingOffset = .2f;
    public float maxRunBobbingOffset = .3f;

    [Header("Audio")]
    public AudioSource audioWalk;

    [Header("Runtime")]
    Vector3 newVelocity;
    bool isGrounded = false;
    bool isJumping = false;

    public ScriptableObject levelData;
    private GameObject escortee;

    public bool lookingAtMedkit = false;

    [SerializeField] private LayerMask interactLayerMask;
    //public GameObject DataHolderObject;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        GetComponent<PlayerHealth>().health = DataHolderScript.passHealth_Player;
        GetComponent<PlayerHealth>().AddHealth(0);

        escortee = GameObject.FindGameObjectWithTag("Escortee");
        //Debug.Log(GetComponent<PlayerHealth>().health);
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal rotation
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);

        newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed; // Colon means otherwise
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                newVelocity.y = jumpSpeed;
                isJumping = true;
            }

        }

        bool isMovingOnGround = (Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f) && isGrounded;

        if (isMovingOnGround){
            float bobbingRate = Input.GetKey(KeyCode.LeftShift) ? runBobbingRate : walkBobbingRate;
            float bobbingOffset = Input.GetKey(KeyCode.LeftShift) ? maxRunBobbingOffset : maxWalkBobbingOffset;
            Vector3 targetHeadPosition = Vector3.up * baseCameraHeight + Vector3.up * (Mathf.PingPong(Time.time * bobbingRate, bobbingOffset) - bobbingOffset * .5f);
            head.localPosition = Vector3.Lerp(head.localPosition, targetHeadPosition, .1f);
        }

        rb.velocity = transform.TransformDirection(newVelocity);

        // Audio
        audioWalk.enabled = isMovingOnGround;
        if(PauseMenu.gamePaused) audioWalk.enabled = false;
        audioWalk.pitch = Input.GetKey(KeyCode.LeftShift) ? 1.75f : 1f;


        

    }

    void FixedUpdate()
    {
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit raycastHit, 6f, interactLayerMask)){
            lookingAtMedkit = true;
        } else {
            lookingAtMedkit = false;
        }
        
        
    }

    void LateUpdate()
    {
        // Vertical rotation
        Vector3 e = head.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * 2f;
        e.x = RestrictAngle(e.x, -85f, 85f);
        head.eulerAngles = e;


    }

    // Clamp the vertical head rotation (Prevent bending backwards)
    public static float RestrictAngle(float angle, float angleMin, float angleMax)
    {
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;

        return angle;
    }

    void OnCollisionStay(Collision col)
    {
        isGrounded = true;
        isJumping = false;
    }

    void OnCollisionExit(Collision col)
    {
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision){ // COLLISIONS!!!!!!!!!!!
        //Debug.Log(collision.gameObject.name);

        if(collision.gameObject.tag == "Portal"){
            //levelData.level ++;
            DataHolderScript.passHealth_Player = GetComponent<PlayerHealth>().health;
            if(escortee != null) DataHolderScript.passHealth_Escortee = escortee.GetComponent<Escortee>().health;

            Debug.Log(DataHolderScript.passHealth_Player);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            //GetComponent<PlayerHealth>().health = DataHolderScript.passHealth_Player;
            //GetComponent<PlayerHealth>().AddHealth(0);
        }

        if(collision.gameObject.name == "Medkit"){
            
        }
    }
    

}
