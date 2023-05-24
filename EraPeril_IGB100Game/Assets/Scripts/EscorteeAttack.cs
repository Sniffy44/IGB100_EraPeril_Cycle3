using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
//using System.Media;
using UnityEngine;

public class EscorteeAttack : MonoBehaviour
{
    public GameObject escorteeWeapon;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public AudioClip attackSound;
    public bool isAttacking = false;
    private float dist_toPlayer;
    private float dist_toEnemy;
    private Transform player;
    public float howclose;
    //public GameObject parent;

    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update(){
        
            //dist_toPlayer = Vector3.Distance(player.position, transform.position);

            if(dist_toPlayer <= howclose){
               // transform.LookAt(player);
            }
            // if (dist <= 2f){
            //     if (canAttack){
            //         Attack();
            //     }           
            // }
        
        
    }

    public void Attack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = escorteeWeapon.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(attackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }
}
