using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator Animator;

    public Transform AttackPoint;
    public LayerMask EnemyLayers;

    public int Damage = 20;
    public float AttackRange = 1f;
    public float AttackRate = 2f;
    private float NextAttackTime = 0f;
    private bool AlreadyAttacking = false;
    private float SecondInAttackRateFormula = 1f;

    void Start()
    {
        Damage = 20;
        AttackRange = 1.5f;
        AttackRate = 2f;
    }

    void Update()
    {
        if (IsMoving())
            return;

        if (Time.time >= NextAttackTime)
        {
            // verifici daca deja ataca ( deja este butonul de atac apasat ), atunci faci direct damage.
            if (AlreadyAttacking)
            {
                Attack();
                NextAttackTime = Time.time + SecondInAttackRateFormula / AttackRate;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                NextAttackTime = Time.time + SecondInAttackRateFormula / AttackRate;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopAttacking();
        }
    }

    private bool IsMoving()
    {
        var currentSpeed = GetComponent<PlayerMovement>().GetCurrentMovementSpeed();
        if (currentSpeed != 0)
        {
            StopAttacking();
            return true;
        }

        return false;
    }


    private void Attack()
    {
        // Attack animation
        Animator.SetTrigger("Attacking");
        AlreadyAttacking = true;

        // Detect enemies in range of attack
        Collider2D[] hitedEnemies =  Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

        // Damage them
        foreach (var enemy in hitedEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(Damage);
        }
    }

    private void StopAttacking()
    {
        Animator.ResetTrigger("Attacking");
        AlreadyAttacking = false;
    }
}
