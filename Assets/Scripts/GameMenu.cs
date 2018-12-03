using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;
    public Text[] namesText;
    public Text[] hpsText;
    public Text[] mpsText;
    public Text[] lvlsText;
    public Text[] expsText;
    public Slider[] expsSliders;
    public Image[] charactersImages;
    public GameObject[] charStatHolder;

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
                menu.SetActive(false);
                GameManager.instance.gameMenuOpen = false;
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
                expsText[i].text = playerStats[i].currentEXP + "/" + playerStats[i].expToNextLevel[playerStats[i].playerLevel]; //$"{playerStats[i].currentEXP} / {playerStats[i].expToNextLevel[playerStats[i].playerLevel]}";
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
}
