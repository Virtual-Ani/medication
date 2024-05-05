using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangeAgentDestination : MonoBehaviour
{
    //[SerializeField] private Vector3 destination;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Call()
    {
        //agent.SetDestination(destination);
        agent.SetDestination(Core.Instance.transform.position);
    }
}
