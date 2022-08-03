using UnityEngine;
using System.Collections;

public class EnemySpawnState : EnemyBaseState
{
    private GameObject target;
    private GameObject targetHead;
    public override void EnterState(EnemyStateMenager enemy)
    {
        target = GameObject.FindGameObjectWithTag("Player");
        targetHead = GameObject.FindGameObjectWithTag("MainCamera");
    }
    public override void UpdateState(EnemyStateMenager enemy)
    {
        Debug.DrawLine(enemy.transform.position, target.transform.position, Color.yellow);
        Debug.DrawLine(enemy.transform.position, targetHead.transform.position, Color.green);
    }
    public override void OnCollisionEnter(EnemyStateMenager enemy, Collision collision)
    {

    }
}
