using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationWrapper : MonoBehaviour
{
    GameObject projectile;
    EnemyStateMenager menager;
    public int maxDamage = 8;
    private Vector3 shootDirection;
    private SFX SFXMenager;
    private RandomFunction random;
    private void Start()
    {
        menager = gameObject.GetComponent<EnemyStateMenager>();
        SFXMenager = gameObject.GetComponentInChildren<SFX>();
        random = GameObject.Find("MathHelper").GetComponentInChildren<RandomFunction>(); 
    }
    private void Update()
    {
        Debug.DrawRay(gameObject.transform.position, menager.target.transform.position - gameObject.transform.position, Color.red);
        Debug.DrawRay(gameObject.transform.position, getSpreadVector(20,menager.target.transform.position - gameObject.transform.position),Color.red);
        Debug.DrawRay(gameObject.transform.position, getSpreadVector(-20,menager.target.transform.position - gameObject.transform.position),Color.red);
    }
    public void GoToSeeState()
    {
        menager.SwitchState(menager.SeeState);
    }
    public void GoToRangeState()
    {
        menager.SwitchState(menager.RangeState);
    }
    public void RangeAtack()
    {
        projectile = menager.projectile;
        projectile.GetComponent<ExplosionProjectile>().target = menager.target;
        projectile.GetComponent<ExplosionProjectile>().parent = gameObject;
        projectile.GetComponent<ExplosionProjectile>().damage = calculateDamage();
        Instantiate(projectile, menager.spawnProjectile.transform.position, Quaternion.identity);
    }
    public void RangeAtackRaycast(int bulletAtOnce)
    {
        float []minus = { -1, 1 };
        RaycastHit hit;
        shootDirection = menager.target.transform.position - gameObject.transform.position;
        for (int i = 0; i < bulletAtOnce; ++i)
        {
            float angleSpread = random.randomNumberThreeSigma(-20f, 20f);
            Vector3 spreadVector = getSpreadVector(angleSpread, shootDirection);
            Debug.DrawRay(gameObject.transform.position, spreadVector, Color.blue, 10000f);
            if (Physics.Raycast(gameObject.transform.position, spreadVector, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    hit.collider.GetComponent<PlayerStats>().GetHit(calculateDamage());
                }
                else if (hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<EnemyHP>().dealDamage(calculateDamage());
                }
            }
        }
    }
    public void MelleAtack()
    {
        if ((menager.target.transform.position - gameObject.transform.position).magnitude < 1.5f)
        {
            if (menager.target.CompareTag("Player"))
            {
                menager.target.GetComponent<PlayerStats>().GetHit(calculateDamage());
            }
            else if (menager.target.CompareTag("Enemy"))
            {
                menager.target.GetComponent<EnemyHP>().dealDamage(calculateDamage());
            }
        }
    }
    public void PlayAtack()
    {
        Debug.Log("hey");
        SFXMenager.PlayAtack();
    }
    private int calculateDamage()
    {
        return Random.Range(1, maxDamage+1) * menager.damageMultiply;
    }
    Vector3 getSpreadVector(float angle,Vector3 vector)
    {
        Vector3 dir;
        dir = Quaternion.AngleAxis(angle, Vector3.up) * vector;
        return dir;
    }
}
