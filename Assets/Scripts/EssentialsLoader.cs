using Boo.Lang.Environments;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject player;

    void Start()
    {
        if (UIFade.instance == null)
        {
            UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>();
        }

        if (PlayerController.instance == null)
        {
            PlayerController.instance = Instantiate(player).GetComponent<PlayerController>();
        }
    }

    void Update()
    {

    }
}
