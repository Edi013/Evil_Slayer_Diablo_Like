using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollowsPlayer : MonoBehaviour
{
    private Transform Destination; 
    public Transform StartLocation;
    public Animator Animator;

    private const float ValueToMapStepWith = 0.01f;

    public float RangeToStopAtFromDestination;
    public float GivenStep;
    
    private float actualStep;
    private Vector2 Movement;
    

    private void Start()
    {
        GameObject myGameObject = GameObject.Find("Player");
        Destination = myGameObject.transform;

        GivenStep = 1f;
        actualStep = GivenStep * ValueToMapStepWith;
        RangeToStopAtFromDestination = 0.5f;
    }

    private void Update()
    {
        // if this check doesn't exists, the enemy will push you while you hit it
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

        var skeletonAttackRange = GetComponent<EnemyAttack>().attackRange;
        Animator.SetFloat("Speed", 1);

        if (Destination.position.x > StartLocation.position.x + skeletonAttackRange)
        {
            StartLocation.position =
                new Vector3(StartLocation.position.x + actualStep, StartLocation.position.y, StartLocation.position.z);
            SetSpeedParameterInAnimatorController(StartLocation.position.x, StartLocation.position.y);
        }
        else
        if (Destination.position.x < StartLocation.position.x - skeletonAttackRange)
        {
            StartLocation.position =
                new Vector3(StartLocation.position.x - actualStep, StartLocation.position.y, StartLocation.position.z);
            SetSpeedParameterInAnimatorController(StartLocation.position.x, StartLocation.position.y);
        }
        else
        if (Destination.position.y > StartLocation.position.y + skeletonAttackRange * 1.3f)
        {
            StartLocation.position =
                new Vector3(StartLocation.position.x, StartLocation.position.y + actualStep, StartLocation.position.z);
            SetSpeedParameterInAnimatorController(StartLocation.position.x, StartLocation.position.y);
        }
        else
        if (Destination.position.y < StartLocation.position.y - skeletonAttackRange)
        {
            StartLocation.position =
                new Vector3(StartLocation.position.x, StartLocation.position.y - actualStep, StartLocation.position.z);
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
