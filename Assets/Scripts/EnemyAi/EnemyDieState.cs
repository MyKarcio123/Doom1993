using UnityEngine;

public class EnemyDieState : EnemyBaseState
{
    public override void EnterState(EnemyStateMenager enemy)
    {
        enemy.animator.Play("Die");
        enemy.controler.PlayDeath();
        enemy.makeCorpse();
    }
    public override void UpdateState(EnemyStateMenager enemy)
    {

    }
    public override void OnCollisionEnter(EnemyStateMenager enemy, Collision collision)
    {

    }
}
