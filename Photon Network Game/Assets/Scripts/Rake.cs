using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rake : MonoBehaviour
{
    [SerializeField] GameObject destination;
    [SerializeField] NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }
    void Start()
    {
        destination = GameObject.Find("Projector Star");
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(destination.transform.position);
    }
}
