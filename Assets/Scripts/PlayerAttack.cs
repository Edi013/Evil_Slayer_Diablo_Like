using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;

    public int damage = 20;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        } 
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopAttacking();
        }
    }

    private void Attack()
    {
        // Attack animation
        animator.SetTrigger("Attacking");

        // Detect enemies in range of attack
        Collider2D[] hitedEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (var enemy in hitedEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    private void StopAttacking()
    {
        animator.ResetTrigger("Attacking");
    }
}
