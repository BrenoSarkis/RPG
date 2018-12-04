using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
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

    private CharStats[] playerStats;

    void Start()
    {

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
        for (int i = 0; i < statusButtons.Length; i++)
        {
            statusButtons[i].SetActive(playerStats[i].gameObject.activeInHierarchy);
        }
    }
}
