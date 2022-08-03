using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMenager : MonoBehaviour
{
    EnemyBaseState currentState;
    public EnemySpawnState SpawnState = new EnemySpawnState();
    public EnemySeeState SeeState = new EnemySeeState();
    public EnemyRangeState RangeState = new EnemyRangeState();
    public EnemyMeleeState MeleeState = new EnemyMeleeState();
    public EnemyPainState PainState = new EnemyPainState();
    public EnemyDieState DieState = new EnemyDieState();
    public EnemyXDieState XDieState = new EnemyXDieState();
    public Animator animator;
    private AngleController angleController;
    public SFX controler;
    void Start()
    {
        angleController = GetComponent<AngleController>();

        animator = GetComponent<Animator>();

        currentState = SpawnState;

        currentState.EnterState(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this,collision);
    }
    void Update()
    {
        currentState.UpdateState(this);
        animator.SetFloat("spriteRot", angleController.index);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void makeCorpse()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject.GetComponent<NavMeshAgent>());
        gameObject.layer = LayerMask.NameToLayer("Corpse");
        gameObject.tag = "Corpse";
        Component[] components = gameObject.GetComponents<Component>();
        foreach (Component comp in components)
        {
            if (!(comp is CapsuleCollider || comp is Rigidbody || comp is Transform || comp is Animator))
            {
                Destroy(comp);
            }
        }
        Destroy(this);
    }
}
