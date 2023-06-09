using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{
    //public EnemyAttack wc;
    public GameObject hitParticle;
    private int damageAmount;
    public int damageMitigator = 0;


    // Start is called before the first frame update
    void Start()
    {
        damageAmount = GetComponentInParent<EnemyAttack>().weaponData.damage;
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
        if (other.tag == "Player" && GetComponentInParent<EnemyAttack>().isAttacking){

            Instantiate(hitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            other.gameObject.TryGetComponent(out PlayerHealth health);
            health.DecreaseHealth(damageAmount - damageMitigator);

            GetComponentInParent<EnemyAttack>().isAttacking = false;
        }

        if (other.tag == "Escortee" && GetComponentInParent<EnemyAttack>().isAttacking){
            
            Instantiate(hitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            var escort = other.GetComponent<Collider>().GetComponent<Escortee>();
            escort.Hit(damageAmount);    

            GetComponentInParent<EnemyAttack>().isAttacking = false;
        }

    }
}
