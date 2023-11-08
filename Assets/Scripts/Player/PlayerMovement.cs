using UnityEngine;

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
    public Transform PlayerGroundLevel;

    public float MovementSpeed;
    public float CurrentMovementSpeed;

    private float  minX;
    private float  maxX;
    private float  minY;
    private float  maxY;

    void Start()
    {
        MovementSpeed = 6f;
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
        
        if (Player.position.x < minX)
            newPosition.x = minX;
        else 
        if (Player.position.x > maxX)
            newPosition.x = maxX;
        else 
        if (PlayerGroundLevel.position.y < minY)
            newPosition.y = minY + System.Math.Abs(Player.position.y - PlayerGroundLevel.position.y);
        else
        if (PlayerGroundLevel.position.y > maxY)
            newPosition.y = maxY + System.Math.Abs(Player.position.y - PlayerGroundLevel.position.y);

        Player.position = newPosition;
    }
    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + Movement * MovementSpeed * Time.fixedDeltaTime);
    }
}

