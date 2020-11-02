
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public LayerMask whatCanBeClickedon;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit,100,whatCanBeClickedon))
            {
                // move agent
                agent.destination = hit.point;
            }
        }

        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.velocity = Vector3.zero;
        }
    }
}
