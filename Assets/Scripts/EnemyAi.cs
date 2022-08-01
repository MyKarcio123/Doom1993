using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAi : MonoBehaviour
{
    enum State
    {
        Spawn,
        See,
        Die,
        Range,
        Melee,
        Pain
    }
    public Animator animator;
    public SFX controler;
    public Transform target;
    private NavMeshAgent navMeshAgent;
    private AngleController angleController;
    State state;
    void Start()
    {
        angleController = GetComponent<AngleController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        state = State.Spawn;
        StateSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("spriteRot",angleController.index);
        navMeshAgent.SetDestination(target.position);
    }
    void StateSee()
    {

    }
    void StateSpawn()
    {

    }
    void StateRange()
    {

    }
    void StateMelee()
    {

    }
    void StatePain()
    {

    }
    public void StateDie()
    {
        animator.Play("Die");
        controler.PlayDeath();
    }
    void StateXDie()
    {

    }
}
