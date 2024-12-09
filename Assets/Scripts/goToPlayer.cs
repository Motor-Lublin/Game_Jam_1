using UnityEngine;
using UnityEngine.AI;

public class goToPlayer : MonoBehaviour
{
    public GameObject playerTarget;
    Vector3 destination;
    NavMeshAgent agent;
    [SerializeField] float enemySeeRange;
    // 1 TO 100%, 2 to 50% etc
    [SerializeField] float enemyAtackRange;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        destination = agent.transform.position;
        var vectorToTarger = destination - playerTarget.transform.position;
        vectorToTarger.y = 0f;
        if (vectorToTarger.magnitude < enemySeeRange)
        {
            vectorToTarger.x = vectorToTarger.x / enemyAtackRange;
            vectorToTarger.z = vectorToTarger.z / enemyAtackRange;
            if (vectorToTarger.magnitude >= enemyAtackRange)
            {
                destination = playerTarget.transform.position;
                agent.destination = destination;
                if (enemyAtackRange == 1 && vectorToTarger.magnitude < 1.5)
                {
                    agent.destination = transform.position;
                }
            }
            else
            {
                agent.destination = transform.position;
            }        
        }
        else if (vectorToTarger.magnitude >= enemySeeRange)
        {
            agent.destination = transform.position;
        }
    }
}
