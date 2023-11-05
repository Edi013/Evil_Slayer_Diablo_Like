using System;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]


public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // Movement
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);

    }

}

