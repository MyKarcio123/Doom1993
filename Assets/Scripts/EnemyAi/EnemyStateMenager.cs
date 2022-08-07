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
    public int damage = 3;
    public Animator animator;
    public NavMeshAgent agent;
    private AngleController angleController;
    public GameObject target;
    public GameObject projectile;
    public GameObject spawnProjectile;
    public SFX controler;
    void Start()
    {
        angleController = GetComponent<AngleController>();

        animator = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

        SwitchState(SpawnState);
    }
    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this,collision);
    }
    void Update()
    {
        currentState.UpdateState(this);
        animator.SetFloat("spriteRot", angleController.index);
        Debug.Log(currentState);
    }

    public void SwitchState(EnemyBaseState state)
    {
        agent.isStopped = true;
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
    public void rangeAtack()
    {
        projectile.GetComponent<ExplosionProjectile>().target = target;
        projectile.GetComponent<ExplosionProjectile>().parent = gameObject;
        projectile.GetComponent<ExplosionProjectile>().damage = calculateDamage();
        Instantiate(projectile, spawnProjectile.transform.position,Quaternion.identity);
    }
    public void melleAtack()
    {
        if ((target.transform.position - gameObject.transform.position).magnitude < 1.5f)
        {
            if (target.CompareTag("Player"))
            {
                target.GetComponent<PlayerStats>().GetHit(calculateDamage());
            }
            else if (target.CompareTag("Enemy"))
            {
                target.GetComponent<EnemyHP>().dealDamage(calculateDamage());
            }
        }
    }
    private int calculateDamage()
    {
        return Random.Range(1, 9) * damage;
    }
    public void RestartState()
    {
        SwitchState(SeeState);
    }
}
