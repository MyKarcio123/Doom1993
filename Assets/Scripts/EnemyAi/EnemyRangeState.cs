using UnityEngine;

public class EnemyRangeState : EnemyBaseState
{
    public override void EnterState(EnemyStateMenager enemy)
    {
        enemy.animator.Play("Range");
    }
    public override void UpdateState(EnemyStateMenager enemy)
    {
        enemy.transform.LookAt(new Vector3(enemy.target.transform.position.x, enemy.transform.position.y, enemy.target.transform.position.z));
    }
    public override void OnCollisionEnter(EnemyStateMenager enemy, Collision collision)
    {

    }

}
