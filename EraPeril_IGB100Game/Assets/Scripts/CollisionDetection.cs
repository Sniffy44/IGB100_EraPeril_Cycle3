using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    //public WeaponController wc;
    public GameObject HitParticle;
    public AudioClip hitSound;
    private int damageAmount;


    // Start is called before the first frame update
    void Start()
    {
        damageAmount = GetComponent<WeaponController>().weaponData.damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && WeaponController.isAttacking)
        {
            //UnityEngine.Debug.Log(other.name);
            //other.GetComponent<Animator>().SetTrigger("Hit");
            if(HitParticle != null) Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            var enemy = other.GetComponent<Collider>().GetComponent<Enemy>();
            
            enemy.Hit(damageAmount);                                                                                                                   

            //UnityEngine.Debug.Log(damageAmount);

            AudioSource audioC = GetComponentInParent<AudioSource>();
            audioC.PlayOneShot(hitSound, 0f);

            Vector3 dir = new Vector3(0,10,0);

            //enemy.GetComponent<Rigidbody>().AddForce(enemy.GetComponent<Rigidbody>().velocity * -1, ForceMode.VelocityChange);
            //StartCoroutine(Bounce());

            //other.GetComponent<Rigidbody>().AddForce(dir, ForceMode.VelocityChange);
            
        }

        if(other.tag == "Medkit" && WeaponController.isAttacking){
            Vector3 dir = new Vector3(0,10,0);
            other.GetComponent<Rigidbody>().AddForce(dir, ForceMode.VelocityChange);
            //other.gameObject.TryGetComponent(out PlayerHealth health);
            //GetComponentInParent<PlayerHealth>().AddHealth(50);
        }
        // else if(other.tag == "Player")
        // {
        //     if(HitParticle != null) Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
        //     other.gameObject.TryGetComponent(out PlayerHealth health);
        //     health.DecreaseHealth(damageAmount);
        // }

    }
}
