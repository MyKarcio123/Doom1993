using UnityEngine;

public class EnemyRangeState : EnemyBaseState
{
    public override void EnterState(EnemyStateMenager enemy)
    {
        if ((enemy.target.transform.position - enemy.gameObject.transform.position).magnitude >= 1.5)
        {
            enemy.animator.Play("Range");
        }
        else
        {
            enemy.controler.PlayMelee();
            enemy.animator.Play("Melee");
        }
    }
    public override void UpdateState(EnemyStateMenager enemy)
    {
        enemy.transform.LookAt(new Vector3(enemy.target.transform.position.x, enemy.transform.position.y, enemy.target.transform.position.z));
    }
    public override void OnCollisionEnter(EnemyStateMenager enemy, Collision collision)
    {

    }

}
