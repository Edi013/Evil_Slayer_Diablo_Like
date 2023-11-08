using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Animator animator;

    private Score score;

    void Start()
    {
        currentHealth = maxHealth;
        var scoreText = GameObject.Find("ScoreText");
        score = scoreText.GetComponent<Score>();
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
                score.IncrementScore();
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
    }
}
