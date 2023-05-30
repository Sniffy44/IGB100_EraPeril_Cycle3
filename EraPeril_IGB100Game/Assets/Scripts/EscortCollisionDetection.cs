using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscortCollisionDetection : MonoBehaviour
{
    //public EnemyAttack wc;
    public GameObject hitParticle;
    private int damageAmount;


    // Start is called before the first frame update
    void Start()
    {
        damageAmount = GetComponentInParent<EscorteeAttack>().weaponData.damage;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        // if (other.tag == "Enemy" && wc.isAttacking)
        // {
        //     //Debug.Log(other.name);
        //     //other.GetComponent<Animator>().SetTrigger("Hit");
        //     Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
        //     var enemy = other.GetComponent<Collider>().GetComponent<Enemy>();
            
        //     enemy.Hit(damageAmount);
            
        // }
        if (other.tag == "Enemy" && GetComponentInParent<EscorteeAttack>().isAttacking)
        {
            Instantiate(hitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            
            var enemy = other.GetComponent<Collider>().GetComponent<Enemy>();
            enemy.Hit(damageAmount);  

            GetComponentInParent<EscorteeAttack>().isAttacking = false;
        }

    }
}