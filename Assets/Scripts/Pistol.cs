using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pistol : MonoBehaviour
{
    public PlayerStats script;
    public Transform shotingPoint;
    public LayerMask user;
    public Animator animator;
    public int maxDamage;
    public int shotsAtOnce;
    public int range;
    public int ammoType;
    public float cooldown;
    public AudioSource audioSource;
    public TextMeshProUGUI ammoText;
    public GameObject puff;
    public GameObject bloodPuff;
    public bool allwaysSpread;
    public float angleSpreadMax = 5.5f;
    public float angleSpreadMin = 2;
    public RandomFunction random;
    public WeaponController weaponController;
    private bool shooting = false;
    private int ammo;
    private int shotedBullet = 0;
    private int[] minus = new int[2] { -1, 1 };
    void Start()
    {
        getAmmo();
    }
    void Update()
    {
        PrepToShot();
    }
    void AmmoMenager()
    {
        ammo -= 1;
        ammoText.SetText(ammo + "");
        if (ammoType == 0) script.setBullet(-1);
        else if (ammoType == 1) script.setShell(-1);
        else if (ammoType == 2) script.setRocket(-1);
        else script.setCell(-1);
    }
    void PrepToShot()
    {
        if (Input.GetMouseButton(0) && ammo - 1 >= 0 && !shooting && !weaponController.atAnimation)
        {
            shooting = true;
            animator.SetBool("Shooting", true);
            animator.Play("Shot");
        }
        else if((!Input.GetMouseButton(0) && shooting) || ammo<=0)
        {
            Invoke("StopShooting", cooldown);
            animator.SetBool("Shooting", false);
            shotedBullet = 0;
        }
    }
    //function Shot is Invoke by AnimationEvent to perfectTime
    void Shot()
    {
        //shootingPoint.forward - for first shoot
        //getSpreadVector(angle) - for each other shoot
        AmmoMenager();
        RaycastHit hit;
        Vector3 dir;
        for(int i = 0; i < shotsAtOnce; i++) { 
            if (shotedBullet>0 || allwaysSpread) {
                float angle = random.randomNumberThreeSigma(angleSpreadMin, angleSpreadMax);
                if (angleSpreadMin >= 0)
                {
                    int randomIndex = Random.Range(0, 2);
                    angle = angle * minus[randomIndex];
                }
                dir = getSpreadVector(angle);
            }
            else
            {
                dir = shotingPoint.forward;
            }
            Debug.DrawRay(shotingPoint.position, dir*10000f, Color.green, 9999);
            if (Physics.Raycast(shotingPoint.position, dir, out hit, range, ~user))
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    Instantiate(bloodPuff, hit.point + new Vector3(0f, 0.01f, -0.01f), Quaternion.LookRotation(hit.normal));
                    int damageAtPellot = Random.Range(1, maxDamage+1) * 5;
                    hit.collider.gameObject.GetComponent<EnemyHP>().dealDamage(damageAtPellot);
                }
                else { 
                    Instantiate(puff, hit.point + new Vector3(0f, 0.01f, -0.01f), Quaternion.LookRotation(hit.normal));
                }
            }
        }
        shotedBullet++;
        audioSource.Play(0);
    }
    void StopShooting()
    {
        shooting = false;
    }
    void getAmmo()
    {
        if (ammoType == 0) ammo = script.getBullet();
        else if (ammoType == 1) ammo = script.getShell();
        else if (ammoType == 2) ammo = script.getRocket();
        else ammo = script.getCell();
        ammoText.SetText(ammo+"");
    }
    Vector3 getSpreadVector(float angle)
    {
        Vector3 dir;
        dir = Quaternion.AngleAxis(angle, Vector3.up) * shotingPoint.forward;
        return dir;
    }
    public void EndAnim()
    {
        weaponController.EndAnim();
    }
    public void AnimationEnded()
    {
        weaponController.AnimationEnded();
    }
}
