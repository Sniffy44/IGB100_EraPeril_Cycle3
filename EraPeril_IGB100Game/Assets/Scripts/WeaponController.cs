using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public GameObject Weapon;
    public bool CanAttack = true;
    public float AttackCoolDown = 1.0f;
    public AudioClip SwordAttackSound;
    public bool isAttacking = false;
    public bool Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player = true)
        {
            if (Input.GetMouseButtonDown(0))
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
        Animator anim = Weapon.GetComponent<Animator>();
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
