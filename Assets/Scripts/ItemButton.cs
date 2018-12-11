using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Image buttonImage;
    public Text amountText;
    public int buttonValue;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Press()
    {
        if (GameManager.instance.itensHeld[buttonValue] != "")
        {
          
        }
    }
}
