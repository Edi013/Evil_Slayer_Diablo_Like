using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject SkeletonGameObject;
    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;    
    }

    public void TakeDamage(int damage)
    {
        GetComponent<EnemyAttack>().DelayAttack();

        if(currentHealth > 0)
        {
            currentHealth -= damage;

            animator.SetTrigger("TakeHit");

            if(currentHealth <= 0) 
            {
                Die();
                return;
            }
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<EnemyFollowsPlayer>().enabled = false;
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<EnemyHealth>().enabled = false;
    }
}
