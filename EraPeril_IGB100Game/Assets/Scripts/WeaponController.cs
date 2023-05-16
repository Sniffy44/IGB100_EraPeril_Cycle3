using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    
    [SerializeField] public WeaponData weaponData;

    //[HideInInspector]
    public GameObject weapon;

    public bool player = true;

    [HideInInspector] 
    public float attackCoolDown;// = weaponData.swingTime;
    [HideInInspector] 
    public AudioClip attackSound;// = weaponData.attackAudioClip;
    [HideInInspector] 
    public bool isAttacking = false;
    [HideInInspector] 
    public bool canAttack = true;

    
    

    // Start is called before the first frame update
    void Start()
    {
        attackCoolDown = weaponData.swingTime;
        attackSound = weaponData.attackAudioClip;
        //weapon = weaponData.weaponModelObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (canAttack)
                {
                    Attack();
                }
            }
        }
        
    }

    public void Attack()
    {
        //Debug.Log("im swingin boi");
        isAttacking = true;
        canAttack = false;

        Animator anim = weapon.GetComponent<Animator>();
        //weapon.SetActive(true);
        anim.SetTrigger("Attack");
        
        AudioSource audioC = GetComponentInParent<AudioSource>();
        audioC.PlayOneShot(attackSound, 0.3f);

        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCoolDown);
        canAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(attackCoolDown);
        isAttacking = false;
    }
}
