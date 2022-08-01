using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    int currentWeapon = 0;
    int nextWeapon = 0;
    public PlayerStats playerStats;
    public GameObject [] weapons;
    private Animator currentAnimator;
    public bool atAnimation = false;
    private void Start()
    {
        currentAnimator = weapons[currentWeapon].GetComponent<Animator>();
    }
    void Update()
    {
        CheckForSwap();
    }
    void CheckForSwap()
    {
        for (int i = 0; i <= 5; i++)
        {
            if (Input.GetKeyDown("" + (i+2)))
            {
                if (playerStats.weapons[i] == true && i != currentWeapon)
                {
                    nextWeapon = i;
                    atAnimation = true;
                    currentAnimator.Play("GoDown");
                }
            }
        }
    }
    public void EndAnim()
    {
        weapons[currentWeapon].SetActive(false);
        weapons[nextWeapon].SetActive(true);
        currentWeapon = nextWeapon;
        currentAnimator = weapons[currentWeapon].GetComponent<Animator>();
    }
    public void AnimationEnded()
    {
        atAnimation = false;
    }
}
