using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    
    [SerializeField] public WeaponData weaponData;

    //[HideInInspector]
    public GameObject weapon;

    public bool player = true;

    [HideInInspector] public float attackCoolDown;// = weaponData.swingTime;
    [HideInInspector] public float attackingTime;
    [HideInInspector] public AudioClip attackSound;// = weaponData.attackAudioClip;
    [HideInInspector] public float swingAudioVolume;
    [HideInInspector] public static bool isAttacking = false;
    [HideInInspector] public static bool canAttack = true;
    

    
    

    // Start is called before the first frame update
    void Start()
    {
        attackCoolDown = weaponData.swingTime;
        attackSound = weaponData.attackAudioClip;
        swingAudioVolume = weaponData.audioVolume;
        attackingTime = weaponData.attackingTime;
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

        //Debug.Log(isAttacking);
        
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
        audioC.PlayOneShot(attackSound, swingAudioVolume);

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
        yield return new WaitForSeconds(attackingTime);
        isAttacking = false;
    }
}
