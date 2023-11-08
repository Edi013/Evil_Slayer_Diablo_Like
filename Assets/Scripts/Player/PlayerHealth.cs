using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator Animator;
    public Healthbar Healthbar;
    public GameManager GameManager;

    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        Healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            Healthbar.SetHealth(currentHealth);

            Animator.SetTrigger("TakeHit");

            if (currentHealth <= 0)
            {
                Healthbar.SetHealth(0);
                Die();
            }
        }
    }

    private void Die()
    {
        Animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        GetComponent<PlayerHealth>().enabled = false;

        new WaitForSeconds(5.0f);

        GameManager.EndGame();
    }
}
