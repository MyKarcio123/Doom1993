using UnityEngine;
using UnityEngine.AI;

public class EnemySeeState : EnemyBaseState
{
    float moveCount;
    public override void EnterState(EnemyStateMenager enemy)
    {
        enemy.agent.isStopped = false;
        moveCount = Random.Range(0f, 5f);
    }
    public override void UpdateState(EnemyStateMenager enemy)
    {
        enemy.agent.SetDestination(enemy.target.transform.position);
        if ((enemy.target.transform.position - enemy.gameObject.transform.position).magnitude < 1.5)
        {
            enemy.SwitchState(enemy.RangeState);
        }
        else if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;
        }
        else
        {
            enemy.SwitchState(enemy.RangeState);
        }
    }
    public override void OnCollisionEnter(EnemyStateMenager enemy, Collision collision)
    {
        
    }

}
