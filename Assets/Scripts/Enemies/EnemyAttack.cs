using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator animator;
    public GameObject player;

    public Transform attackPoint;
    public LayerMask playersLayer;

    public int damage = 5;
    public float attackRange = 1f;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;
    private float secondInAttackRateFormula = 2f;
    private float animationDuration = 0.7f;

    void Start()
    {
        damage = 5;
        attackRange = 1f;
        attackRate = 1f;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {

            Collider2D[] hitedEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playersLayer);

            if (hitedEnemies == null || hitedEnemies.Length == 0)
            {
                Move();
                return;
            }

            StartCoroutine(Attack());
            nextAttackTime = Time.time + secondInAttackRateFormula / attackRate;
        }
    }

    private void Move()
    {
        GetComponent<EnemyFollowsPlayer>().MoveTowardsPlayer();
    }

    private IEnumerator Attack()
    {
        // Attack animation
        animator.SetTrigger("Attacking");

        // wait the animation to play out
        yield return new WaitForSecondsRealtime(animationDuration);

        // Detect enemies in range of attack
        Collider2D[] hitedEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playersLayer);
        
        // Damage them
        foreach (var enemy in hitedEnemies)
        {
            enemy.GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        StopCoroutine(Attack());
        StopAttacking();
    }

    private void StopAttacking()
    {
        animator.ResetTrigger("Attacking");
    }
}
