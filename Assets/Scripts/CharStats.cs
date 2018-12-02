﻿using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;

    public int playerLevel = 1;
    public int currentEXP = 0;
    public int[] expToNextLevel;
    public int baseEXP = 1000;

    public int maxLevel = 100;
    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;  
    public int strength;
    public int defense;
    public int weaponPower;
    public int armorPower;
    public string equippedWeapon;
    public string equippedArmor;
    public Sprite charImage;

    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - i] * 1.05f);
        }
    }

    void Update()
    {

    }

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;
    }
}
