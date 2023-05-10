using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    public GameObject HitParticle;
    public int damageAmount;


    // Start is called before the first frame update
    void Start()
    {
        damageAmount = wc.weaponData.damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && wc.isAttacking)
        {
            //Debug.Log(other.name);
            //other.GetComponent<Animator>().SetTrigger("Hit");
            Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            var enemy = other.GetComponent<Collider>().GetComponent<Enemy>();
            if (enemy.health > 1)
            {
                enemy.Hit();
            }
            else
            {
                enemy.Die();
            }
        }
        else if(other.tag == "Player" && wc.isAttacking)
        {
            Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            other.gameObject.TryGetComponent(out PlayerHealth health);
            health.DecreaseHealth(damageAmount);
        }

    }
}
