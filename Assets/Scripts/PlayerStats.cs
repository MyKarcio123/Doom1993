using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int armorProt = 3;
    [SerializeField]
    private int health;
    [SerializeField]
    private int armor;
    [SerializeField]
    private int bull;
    [SerializeField]
    private int shel;
    [SerializeField]
    private int rokt;
    [SerializeField]
    private int cell;
    public int maxBull;
    public int maxShel;
    public int maxRokt;
    public int maxCell;
    [SerializeField]
    public bool[] weapons = { false, false, false, false, false, false, false };
    [SerializeField]
    private TextMeshProUGUI healthText;    
    [SerializeField]
    private TextMeshProUGUI armorText;
    [SerializeField]
    private Image faceImage;
    [SerializeField]
    private Sprite[] face = new Sprite[5*8];
    [SerializeField]
    private TextMeshProUGUI[] ammo = new TextMeshProUGUI[8];
    [SerializeField]
    private Sprite die;
    [SerializeField]
    private Sprite godMode;
    private Sprite[,] faces = new Sprite[5,8];
    [SerializeField]
    private Image[] weaponIndicatorImage = new Image[6];
    [SerializeField]
    private Sprite[] weaponIndicatorSprite = new Sprite[12];
    void Start()
    {
        linearArray(faces);
        setFace();
        setHealth();
        setAmmo();
        setWeapons();
        setArmor();
    }
    public void GetHit(int damage)
    {
        int damageToArmor = damage / armorProt;
        int damageToHp = damage - damageToArmor;
        armor -= damageToArmor;
        if (armor < 0)
        {
            damageToHp -= armor;
            armor = 0;
        }
        int afterHit = health - damageToHp;
        setFace(health,afterHit);
        health = afterHit;
        setHealth();
        setArmor();
    }
    public void SetNewHP(int hp,int maxAdded)
    {
        int afterHP = health + hp;
        if (afterHP > maxAdded) afterHP = maxAdded;
        setFace(health, afterHP);
        health = afterHP;
        setHealth();
    }    
    public void SetNewArmor(int addArmor,int maxAdded,int newprot)
    {
        int afterArmor = armor + addArmor;
        if (afterArmor > maxAdded) afterArmor = maxAdded;
        armor = afterArmor;
        if (newprot != 0) armorProt = newprot;
        setArmor();
    }
    void linearArray(Sprite[,] faces)
    {
        for (int i = 0; i < 5; ++i)
        {
            for (int j = 0; j < 8; ++j)
            {
                faces[i, j] = face[i * 8 + j];
            }
        }
    }
    void setFace(int beforeHit=0, int afterHit=0)
    {
        int healthType = 0;
        if (afterHit >= 80) healthType = 0;
        else if (afterHit >= 60) healthType = 1;
        else if (afterHit >= 40) healthType = 2;
        else if (afterHit >= 20) healthType = 3;
        else if (afterHit >= 1) healthType = 4;
        else faceImage.sprite = die;
        if (beforeHit - afterHit >= 20) faceImage.sprite = faces[healthType, 5];
        else faceImage.sprite = faces[healthType, 1];
    }
    void setHealth()
    {
        healthText.SetText(health + "%");
    }
    void setArmor()
    {
        armorText.SetText(armor + "%");
    }
    void setAmmo()
    {
        ammo[0].SetText(bull+"");
        ammo[1].SetText(shel+"");
        ammo[2].SetText(rokt+"");
        ammo[3].SetText(cell+"");
        ammo[4].SetText(maxBull+"");
        ammo[5].SetText(maxShel+"");
        ammo[6].SetText(maxRokt+"");
        ammo[7].SetText(maxCell+"");
    }
    void setWeapons()
    {
        for (int i = 0; i <= 5; ++i)
        {
            if (weapons[i]) weaponIndicatorImage[i].sprite = weaponIndicatorSprite[i + 6];
            else weaponIndicatorImage[i].sprite = weaponIndicatorSprite[i];
        }
    }
    public int getBullet()
    {
        return bull;
    }
    public void setBullet(int val)
    {
        bull += val;
        ammo[0].SetText(bull + "");
    }    
    public int getShell()
    {
        return shel;
    }
    public void setShell(int val)
    {
        shel += val;
        ammo[1].SetText(shel + "");
    }    
    public int getRocket()
    {
        return rokt;
    }
    public void setRocket(int val)
    {
        rokt += val;
        ammo[2].SetText(rokt + "");
    }    
    public int getCell()
    {
        return cell;
    }
    public void setCell(int val)
    {
        cell += val;
        ammo[3].SetText(cell + "");
    }
    public int getHealth()
    {
        return health;
    }    
    public int getArmor()
    {
        return armor;
    }
}
