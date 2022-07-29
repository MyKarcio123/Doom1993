using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    State state;
    void Start()
    {
        state = State.Spawn;
        StateSpawn();
    }

    // Update is called once per frame
    void Update()
    {

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
