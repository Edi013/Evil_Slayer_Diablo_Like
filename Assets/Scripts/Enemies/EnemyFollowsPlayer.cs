using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowsPlayer : MonoBehaviour
{
    public Transform target; 
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveTowardsPlayer()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}
