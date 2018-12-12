using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public static GameMenu instance;

    public GameObject menu;
    public GameObject[] windows;

    public Text[] namesText;
    public Text[] hpsText;
    public Text[] mpsText;
    public Text[] lvlsText;
    public Text[] expsText;
    public Slider[] expsSliders;
    public Image[] charactersImages;
    public GameObject[] charStatHolder;
    public GameObject[] statusButtons;
    public Text statusName;
    public Text statusHp;
    public Text statusMP;
    public Text statusStrength;
    public Text statusDefense;
    public Text statusWeaponEquipped;
    public Text statusWeaponPower;
    public Text statusArmorEquipped;
    public Text statusArmorPower;
    public Text statusExp;
    public Image statusCharImage;

    public ItemButton[] itemButtons;
    public string selectedItem;
    public Item activeItem;
    public Text itemName;
    public Text itemDescription;
    public Text useButtonText;

    private CharStats[] playerStats;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (menu.activeInHierarchy)
            {
                CloseMenu();
            }
            else
            {
                menu.SetActive(true);
                GameManager.instance.gameMenuOpen = true;
                UpdateMainStats();
            }
        }
    }

    public void UpdateMainStats()
    {
        playerStats = GameManager.instance.playerStats;

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (playerStats[i].gameObject.activeInHierarchy)
            {
                charStatHolder[i].SetActive(true);
                namesText[i].text = playerStats[i].charName;
                hpsText[i].text = $"HP: {playerStats[i].currentHP}/{playerStats[i].maxHP}";
                mpsText[i].text = $"MP: {playerStats[i].currentMP}/{playerStats[i].maxMP}";
                lvlsText[i].text = $"Lvl: {playerStats[i].playerLevel}";
                expsText[i].text = $"{playerStats[i].currentEXP}/{playerStats[i].expToNextLevel[playerStats[i].playerLevel]}";
                expsSliders[i].maxValue = playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expsSliders[i].value = playerStats[i].currentEXP;
                charactersImages[i].sprite = playerStats[i].charImage;
            }
            else
            {
                charStatHolder[i].SetActive(false);
            }
        }
    }

    public void ToggleWindow(int windowIndex)
    {
        UpdateMainStats();

        for (int i = 0; i < windows.Length; i++)
        {
            if (i == windowIndex)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }

    public void CloseMenu()
    {
        foreach (var window in windows)
        {
            window.SetActive(false);
        }

        menu.SetActive(false);
        GameManager.instance.gameMenuOpen = false;
    }

    public void OpenStatus()
    {
        UpdateMainStats();
        StatusChar(0);

        for (int i = 0; i < statusButtons.Length; i++)
        {
            statusButtons[i].SetActive(playerStats[i].gameObject.activeInHierarchy);
            statusButtons[i].GetComponentInChildren<Text>().text = playerStats[i].charName;
        }
    }

    public void StatusChar(int selectedIndex)
    {
        statusName.text = playerStats[selectedIndex].charName;
        statusHp.text = $"HP: {playerStats[selectedIndex].currentHP}/{playerStats[selectedIndex].maxHP}";
        statusMP.text = $"MP: {playerStats[selectedIndex].currentMP}/{playerStats[selectedIndex].maxMP}";
        statusStrength.text = playerStats[selectedIndex].strength.ToString();
        statusDefense.text = playerStats[selectedIndex].defense.ToString();
        statusWeaponEquipped.text = String.IsNullOrWhiteSpace(playerStats[selectedIndex].equippedWeapon) ? "None" : playerStats[selectedIndex].equippedWeapon;
        statusWeaponPower.text = playerStats[selectedIndex].weaponPower.ToString();
        statusArmorEquipped.text = String.IsNullOrWhiteSpace(playerStats[selectedIndex].equippedArmor) ? "None" : playerStats[selectedIndex].equippedArmor;
        statusArmorPower.text = playerStats[selectedIndex].armorPower.ToString();
        statusExp.text = (playerStats[selectedIndex].expToNextLevel[playerStats[selectedIndex].playerLevel] - playerStats[selectedIndex].currentEXP).ToString();
        statusCharImage.sprite = playerStats[selectedIndex].charImage;
    }

    public void ShowItens()
    {
        GameManager.instance.SortItens();
        for (int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].buttonValue = i;

            if (!String.IsNullOrWhiteSpace(GameManager.instance.itensHeld[i]))
            {
                itemButtons[i].buttonImage.gameObject.SetActive(true); 
                itemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itensHeld[i]).itemSprite;
                itemButtons[i].amountText.text = GameManager.instance.numberOfItens[i].ToString();
            }
            else
            {
                itemButtons[i].buttonImage.gameObject.SetActive(false);
                itemButtons[i].amountText.text = "";
            }
        }
    }

    public void SelectItem(Item newItem)
    {
        activeItem = newItem;

        if (activeItem.isItem)
        {
            useButtonText.text = "Use";
        }

        if (activeItem.isArmor || activeItem.isWeapon)
        {
            useButtonText.text = "Equip";
        }

        itemName.text = newItem.itemName;
        itemDescription.text = newItem.description;
    }

    public void DiscardItem()
    {
        if (useGUILayout)
        {
            
        }
    }
}