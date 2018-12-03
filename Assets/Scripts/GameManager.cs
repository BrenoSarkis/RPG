﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CharStats[] playerStats;

    public bool gameMenuOpen;
    public bool dialogActive;
    public bool fadingBetweenAreas;
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
}
