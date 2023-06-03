using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
//using System.Media;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public GameObject enemyWeapon;
    private float dist;
    private Transform player;
    private Transform escort;
    public float howclose;
    public float attackSlownessFactor;

    [SerializeField] public WeaponData weaponData;   

    [HideInInspector] public float attackCooldown;// = weaponData.swingTime;
    [HideInInspector] public float attackingTime;// = weaponData;
    [HideInInspector] public AudioClip attackSound;// = weaponData.attackAudioClip;
    [HideInInspector] public float swingAudioVolume;// = weaponData;

    [HideInInspector] public bool isAttacking = false;
    [HideInInspector] public bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        attackCooldown = weaponData.swingTime;
        attackSound = weaponData.attackAudioClip;
        swingAudioVolume = weaponData.audioVolume;
        attackingTime = weaponData.attackingTime;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GetComponentInParent<Enemy>().hasDied == false){
            dist = Vector3.Distance(player.position, transform.position);

            //if(dist <= howclose)
            //{
                //transform.LookAt(player);
            //}
            if (dist <= 2.5f)
            {
                transform.LookAt(player);
                if (canAttack)
                {
                    Attack();
                }
            }
        }
        
        
    }

    public void ShouldAttackEscort(float distance){
        if(distance <= 2.5){
            if(canAttack) Attack();
        }
    }

    public void Attack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = enemyWeapon.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(attackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCooldown * attackSlownessFactor);
        canAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(attackingTime);
        isAttacking = false;
    }

}
