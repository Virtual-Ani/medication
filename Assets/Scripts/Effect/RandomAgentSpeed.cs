using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomAgentSpeed : MonoBehaviour
{
    [SerializeField] float min = 0.8f;
    [SerializeField] float max = 1.5f;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Call()
    {
        agent.speed *= Random.Range(min, max);
    }
}
