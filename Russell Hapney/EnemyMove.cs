using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public Transform destination;
    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(destination.position);
    }
}