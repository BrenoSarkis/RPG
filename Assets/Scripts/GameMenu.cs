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
    }
}
