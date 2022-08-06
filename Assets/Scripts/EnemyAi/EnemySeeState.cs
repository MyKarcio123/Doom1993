using UnityEngine;
using UnityEngine.AI;

public class EnemySeeState : EnemyBaseState
{
    float moveCount=3;
    int currentMove;
    int prevMove;
    public override void EnterState(EnemyStateMenager enemy)
    {
        //moveCount = Random.Range(1, 5);
    }
    public override void UpdateState(EnemyStateMenager enemy)
    {
        Debug.Log(moveCount);
        if (moveCount > 0)
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
