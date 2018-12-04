﻿using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CharStats[] playerStats;

    public bool gameMenuOpen;
    public bool dialogActive;
    public bool fadingBetweenAreas;

    public string[] itensHeld;
    public int[] numberOfItens;
    public Item[] referenceItens;

    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (gameMenuOpen || dialogActive || fadingBetweenAreas)
        {
            PlayerController.instance.canMove = false;
        }
        else
        {
            PlayerController.instance.canMove = true;
        }
    }

    public Item GetItemDetails(string itemToGrab)
    {
        return referenceItens.First(ri => ri.itemName == itemToGrab);
    }
}
