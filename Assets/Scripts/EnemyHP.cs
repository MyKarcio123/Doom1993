using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    public void stop()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject.GetComponent<EnemyAi>());
        Destroy(gameObject.GetComponent<NavMeshAgent>());
        gameObject.layer = LayerMask.NameToLayer("Corpse");
        gameObject.tag = "Corpse";
    }
    public void onDie()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = dieSprite;
        Component[] components = gameObject.GetComponents<Component>();
        foreach (Component comp in components)
        {
            if (!(comp is CapsuleCollider || comp is Rigidbody || comp is Transform))
            {
                Destroy(comp);
            }
        }
    }
}
