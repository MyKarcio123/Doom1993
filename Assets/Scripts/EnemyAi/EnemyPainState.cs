using UnityEngine;

public class EnemyPainState : EnemyBaseState
{
    public override void EnterState(EnemyStateMenager enemy)
    {
        enemy.animator.Play("Pain");
        enemy.controler.PlayPain();
    }
    public override void UpdateState(EnemyStateMenager enemy)
    {

    }
    public override void OnCollisionEnter(EnemyStateMenager enemy, Collision collision)
    {

    }
}
