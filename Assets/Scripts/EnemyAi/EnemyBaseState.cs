using UnityEngine;

public abstract class EnemyBaseState
{

    public abstract void EnterState(EnemyStateMenager enemy);
    public abstract void UpdateState(EnemyStateMenager enemy);
    public abstract void OnCollisionEnter(EnemyStateMenager enemy, Collision collision);
}
