using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int health;
    public EnemyAi enemy;
    public GameObject corpse;
    public Sprite dieSprite;
    public void dealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            enemy.StateDie();
        }
    }
    public void onDie()
    {
        GameObject currentCorpse = Instantiate(corpse,gameObject.transform.position,Quaternion.identity);
        currentCorpse.GetComponentInChildren<SpriteRenderer>().sprite = dieSprite;
        Destroy(gameObject);
    }
}
