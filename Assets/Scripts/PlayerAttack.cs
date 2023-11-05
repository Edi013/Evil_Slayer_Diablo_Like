using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public int damage = 20;
    public float attackRange = 1f;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    private bool alreadyAttacking = false;
    private float secondInAttackRateFormula = 1f;

    void Start()
    {
        damage = 20;
        attackRange = 1f;
        attackRate = 2f;
    }

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            // verifici daca deja ataca ( deja este butonul de atac apasat ), atunci faci direct damage.
            if (alreadyAttacking)
            {
                Attack();
                nextAttackTime = Time.time + secondInAttackRateFormula / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("sunt intrat pe space down");
                Attack();
                nextAttackTime = Time.time + secondInAttackRateFormula / attackRate;
            }
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
        alreadyAttacking = true;

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
        alreadyAttacking = false;
    }
}
