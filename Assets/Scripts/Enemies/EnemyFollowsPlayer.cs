using UnityEngine;

public class EnemyFollowsPlayer : MonoBehaviour
{
    public Transform Destination; 
    public Transform StartLocation;
    public Animator Animator;

    private const float ValueToMapStepWith = 0.01f;

    public int RangeToStopAtFromDestination = 1;
    public float GivenStep = 1f;
    
    private float actualStep;
    private Vector2 Movement;


    private void Start()
    {
        actualStep = GivenStep * ValueToMapStepWith;
    }

    private void Update()
    {
        // if this check doesn't exists, the enemy will push you while you hit it
        // It's not a but, it's a feature :)
        // Knockback system by mistake implementation
        if (GetComponent<EnemyAttack>().isHitDelay)
        {
            return;   
        }
        MoveTowardsPlayer();
    }


    public void MoveTowardsPlayer()
    {
        if (Destination == null)
            return;

        Animator.SetFloat("Speed", 1);
        if (Destination.position.x > StartLocation.position.x + RangeToStopAtFromDestination)
        {
            StartLocation.position =
                new Vector3(StartLocation.position.x + actualStep, StartLocation.position.y, StartLocation.position.z);
            SetSpeedParameterInAnimatorController(StartLocation.position.x, StartLocation.position.y);
        }
        else
        if (Destination.position.x < StartLocation.position.x - RangeToStopAtFromDestination)
        {
            StartLocation.position =
                new Vector3(StartLocation.position.x - actualStep, StartLocation.position.y, StartLocation.position.z);
            SetSpeedParameterInAnimatorController(StartLocation.position.x, StartLocation.position.y);
        }
        else
        if (Destination.position.y > StartLocation.position.y + RangeToStopAtFromDestination)
        {
            StartLocation.position =
                new Vector3(StartLocation.position.x, StartLocation.position.y + actualStep, StartLocation.position.z);
            SetSpeedParameterInAnimatorController(StartLocation.position.x, StartLocation.position.y);
        }
        else
        if (Destination.position.y < StartLocation.position.y + RangeToStopAtFromDestination)
        {
            StartLocation.position =
                new Vector3(StartLocation.position.x + actualStep, StartLocation.position.y - actualStep, StartLocation.position.z);
            SetSpeedParameterInAnimatorController(StartLocation.position.x, StartLocation.position.y);
        }
        else
        {
            Animator.SetFloat("Speed", 0);
        }
    }

    private void SetSpeedParameterInAnimatorController(float x, float y)
    {
        Movement.x = x;
        Movement.y = y;

        Animator.SetFloat("Speed", Movement.sqrMagnitude);
    }
}
