using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private PlayerStats playerStats;
    private void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HPItem"))
        {
            HPItem(other);
        }
        else if (other.CompareTag("AmmoItem"))
        {
            AmmoItem(other);
        }
        else if (other.CompareTag("ArmorItem"))
        {
            ArmorItem(other);
        }
    }
    void HPItem(Collider other)
    {
        if (playerStats.getHealth() < other.gameObject.GetComponent<HPItemStats>().maxHealth)
        {
            playerStats.SetNewHP(other.gameObject.GetComponent<HPItemStats>().addHealth, other.gameObject.GetComponent<HPItemStats>().maxHealth);
            Destroy(other.gameObject);
        }
    }
    void ArmorItem(Collider other)
    {
        if (playerStats.getArmor() < other.gameObject.GetComponent<ArmorItemStats>().maxArmor)
        {
            playerStats.SetNewArmor(other.gameObject.GetComponent<ArmorItemStats>().addArmor, other.gameObject.GetComponent<ArmorItemStats>().maxArmor, other.gameObject.GetComponent<ArmorItemStats>().prot);
            Destroy(other.gameObject);
        }
    }
    void AmmoItem(Collider other)
    {
        int type = other.gameObject.GetComponent<AmmoItemStats>().type;
        int adding = other.gameObject.GetComponent<AmmoItemStats>().add;
        Action<int> addFunction;
        int maxAmmo;
        int currentAmmo;
        switch (type)
        {
            case 0:
                currentAmmo = playerStats.getBullet();
                maxAmmo = playerStats.maxBull;
                addFunction = playerStats.setBullet;
                break;
            case 1:
                currentAmmo = playerStats.getShell();
                maxAmmo = playerStats.maxShel;
                addFunction = playerStats.setShell;
                break;
            case 2:
                currentAmmo = playerStats.getRocket();
                maxAmmo = playerStats.maxRokt;
                addFunction = playerStats.setRocket;
                break;
            default:
                currentAmmo = playerStats.getCell();
                maxAmmo = playerStats.maxCell;
                addFunction = playerStats.setCell;
                break;
        }
        if (currentAmmo < maxAmmo)
        {
            if (currentAmmo + adding > maxAmmo) addFunction(maxAmmo - currentAmmo);
            else addFunction(adding);
            Destroy(other.gameObject);
        }
    }
}
