using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{
    public EnemyAttack wc;
    public GameObject HitParticle;
    public int damageAmount = 10;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && wc.isAttacking)
        {
            //Debug.Log(other.name);
            //other.GetComponent<Animator>().SetTrigger("Hit");
            Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            var enemy = other.GetComponent<Collider>().GetComponent<Enemy>();
            
            enemy.Hit(damageAmount);
            
        }
        else if (other.tag == "Player" && wc.isAttacking)
        {
            Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            other.gameObject.TryGetComponent(out PlayerHealth health);
            health.DecreaseHealth(damageAmount);
        }

    }
}
