using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]


public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float CurrentMovementSpeed;
    public Rigidbody2D Rigidbody;
    public Animator Animator;
    public Vector2 Movement;

    private float  minX;
    private float  maxX;
    private float  minY;
    private float  maxY;

    void Start()
    {
        MovementSpeed = 4f;
        minX = GetComponent<BackgroundBoundries>().UpperLeftBoundry.transform.position.x;
        maxX = GetComponent<BackgroundBoundries>().UpperRightBoundry.transform.position.x;
        minY = GetComponent<BackgroundBoundries>().UpperRightBoundry.transform.position.y;
        maxY = GetComponent<BackgroundBoundries>().LowerRightBoundry.transform.position.y;
    }
    // Update is called once per frame
    private void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        CurrentMovementSpeed = Movement.sqrMagnitude;

        

        Animator.SetFloat("Horizontal", Mathf.Clamp(Movement.x, minX, maxX)); // math
        Animator.SetFloat("Vertical", Mathf.Clamp(Movement.y, minX, maxX) );
        Animator.SetFloat("Speed", Movement.sqrMagnitude);
    }

    // Movement
    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + Movement * MovementSpeed * Time.fixedDeltaTime);
    }

}

