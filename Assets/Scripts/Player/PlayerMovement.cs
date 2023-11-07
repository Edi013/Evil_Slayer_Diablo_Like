using System;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]


public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 1f;
    public Rigidbody2D Rigidbody;
    public Animator Animator;
    public Vector2 Movement;

    // Update is called once per frame
    private void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        Animator.SetFloat("Horizontal", Movement.x);
        Animator.SetFloat("Vertical", Movement.y);
        Animator.SetFloat("Speed", Movement.sqrMagnitude);
    }

    // Movement
    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + Movement * MovementSpeed * Time.fixedDeltaTime);
    }

}

