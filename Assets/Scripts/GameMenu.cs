using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;

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
            }
        }
    }
}
