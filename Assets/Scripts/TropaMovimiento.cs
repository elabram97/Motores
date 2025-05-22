
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TropaMovimiento : MonoBehaviour
{
    public Transform target;
    Vector3 destination;
    public NavMeshAgent agent;
    
    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(destination, target.position) > 1.0f)
            {
                
                destination = target.position;
                agent.destination = destination;
            }
        }
 
        
    }


}
