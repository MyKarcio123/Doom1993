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
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = dieSprite;
        gameObject.layer = LayerMask.NameToLayer("Corpse");
        gameObject.tag = "Corpse";
        Component[] components = gameObject.GetComponents<Component>();
        foreach( Component comp in components)
        {
            if(!(comp is CapsuleCollider || comp is Rigidbody || comp is Transform))
            {
                Destroy(comp);
            }
        }
    }
}
