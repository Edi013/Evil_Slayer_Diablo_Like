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
    public bool isHitDelay = false;

    private float nextAttackTime = 0f;
    private float secondsInAttackRateFormula = 2f;
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
            if (isHitDelay)
            {
                isHitDelay = false;
                nextAttackTime += Time.time + 1.5f * secondsInAttackRateFormula / attackRate;
            }

            Collider2D[] hitedEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playersLayer);

            if (hitedEnemies == null || hitedEnemies.Length == 0)
                return;

            StartCoroutine(Attack());

            if(!isHitDelay)
                nextAttackTime = Time.time + secondsInAttackRateFormula / attackRate;
        }
    }

    public void DelayAttack()
    {
        isHitDelay = true;
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
