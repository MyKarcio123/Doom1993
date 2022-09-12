using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHP : MonoBehaviour
{
    public int health;
    public int painStateChance;
    private EnemyStateMenager enemyState;
    private void Start()
    {
        enemyState = gameObject.GetComponent<EnemyStateMenager>();
    }
    public void dealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            enemyState.SwitchState(enemyState.DieState);
        }else if (Random.Range(0, 256) <= painStateChance) //does from painstate can I go again to new painstate ? I guess so if not change
        {
            enemyState.SwitchState(enemyState.PainState);
        }else if (enemyState.currentState == enemyState.SpawnState)
        {
            enemyState.controler.PlaySight();
            enemyState.SwitchState(enemyState.RangeState);
        }
    }

}
