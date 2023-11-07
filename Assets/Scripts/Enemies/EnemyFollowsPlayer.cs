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

    public void MoveTowardsPlayer()
    {
        if (Destination != null)
        {
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
        }
    }

    private void SetSpeedParameterInAnimatorController(float x, float y)
    {
        Movement.x = x;
        Movement.y = y;

        Animator.SetFloat("Speed", Movement.sqrMagnitude);
    }
}
