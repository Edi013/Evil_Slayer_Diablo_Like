using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(BoxCollider2D))]


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public Animator Animator;
    public Vector2 Movement;
    public Transform UpperLeft;
    public Transform UpperRight;
    public Transform LowerLeft;
    public Transform LowerRight;
    public Transform Player;

    public float MovementSpeed;
    public float CurrentMovementSpeed;

    private float  minX;
    private float  maxX;
    private float  minY;
    private float  maxY;

    void Start()
    {
        MovementSpeed = 4f;
        minX = UpperLeft.position.x;
        maxX = UpperRight.position.x;
        minY = LowerRight.position.y;
        maxY = UpperRight.position.y; 
    }

    private void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        BoundriesCheck();

        Animator.SetFloat("Horizontal", Movement.x);
        Animator.SetFloat("Vertical", Movement.y);
        Animator.SetFloat("Speed", Movement.sqrMagnitude);
    }

    public float GetCurrentMovementSpeed()
    {
        return Movement.sqrMagnitude;
    }

    private void BoundriesCheck()
    {
        Vector3 newPosition = Player.position;

        if (newPosition.x < minX)
            newPosition.x = minX;
        else 
        if (newPosition.x > maxX)
            newPosition.x = maxX;
        else 
        if (newPosition.y < minY)
            newPosition.y = minY;
        else 
        if (newPosition.y > maxY)
            newPosition.y = maxY;

        Player.position = newPosition;
    }
    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + Movement * MovementSpeed * Time.fixedDeltaTime);
    }
}

