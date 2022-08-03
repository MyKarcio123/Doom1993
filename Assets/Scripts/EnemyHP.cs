using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHP : MonoBehaviour
{
    public int health;
    public EnemyStateMenager enemyState;
    public GameObject corpse;
    public Sprite dieSprite;
    public void dealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            enemyState.SwitchState(enemyState.DieState);
        }
    }

}
