using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

enum State{
    WALK,
    ATTACK,
    DIE,
    NONE
}

public class Rake : MonoBehaviour
{
    [SerializeField] State state;
    [SerializeField] Animator animator;

    [SerializeField] GameObject destination;
    [SerializeField] NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        state = State.WALK;
        destination = GameObject.Find("Projector Star");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projector Star"))
        {
            state = State.ATTACK;
        }
    }
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.WALK:
                Walk();
                break;
            case State.ATTACK:
                Attack();
                break;
            case State.DIE:
                Die();
                break;
            case State.NONE://예외처리
                break;
            default:
                break;
        }
    }

    public void Walk()
    {
        navMeshAgent.SetDestination(destination.transform.position);
    }

    public void Attack()
    {
        animator.Play("Attack");
    }
    
    public void Die()
    {
        if(state != State.NONE)
        {
            state = State.DIE;
            //navMeshAgent.speed = 0; //죽었을 경우 움직임 X 하도록  or //navMeshAgent.isStopped = true;
            navMeshAgent.isStopped = true;
            animator.SetTrigger("Die");
            state = State.NONE;
        }
    }

    public void Release()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
