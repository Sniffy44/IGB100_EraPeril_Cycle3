using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
//using System.Media;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public GameObject EnemyWeapon;
    public bool CanAttack = true;
    public float AttackCoolDown = 1.0f;
    public AudioClip SwordAttackSound;
    public bool isAttacking = false;
    private float dist;
    private Transform player;
    public float howclose;
    //public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponentInParent<Enemy>().hasDied == false){
            dist = Vector3.Distance(player.position, transform.position);

            if(dist <= howclose)
            {
                transform.LookAt(player);
            }
            if (dist <= 2f)
            {
                if (CanAttack)
                {
                    SwordAttack();
                }
            }
        }
        
        
    }

    public void SwordAttack()
    {
        isAttacking = true;
        CanAttack = false;
        Animator anim = EnemyWeapon.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCoolDown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }

}
