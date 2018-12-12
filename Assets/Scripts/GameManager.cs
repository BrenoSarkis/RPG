using System.Linq;
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

    public void SortItens()
    {
        itensHeld = itensHeld.OrderByDescending(i => i != "").ToArray();
        numberOfItens = numberOfItens.OrderByDescending(i => i != 0).ToArray();
    }

    public void AddItem(string itemToAdd)
    {
        var newItemSlot = itensHeld.Where((item, index) => itensHeld[index] == "" || itensHeld[index] == itemToAdd)
                                   .Select((item, index) => new { index })
                                   .FirstOrDefault();

        var foundSpaceForItem = newItemSlot != null;

        if (foundSpaceForItem)
        {
            var itemExists = referenceItens.Any(i => i.itemName == itemToAdd);

            if (itemExists)
            {
                itensHeld[newItemSlot.index] = itemToAdd;
                numberOfItens[newItemSlot.index]++;
            }
            else
            {
                Debug.LogError($"{itemToAdd} does not exist.");
            }
        }

        GameMenu.instance.ShowItens();
    }

    public void RemoveItem(string itemToRemove)
    {
        var itemSlot = itensHeld.Where((item, index) =>  itensHeld[index] == itemToRemove)
                       .Select((item, index) => new { index })
                       .FirstOrDefault();

        var foundItem = itemSlot != null;

        if (foundItem)
        {
            numberOfItens[itemSlot.index]--;
            if (numberOfItens[itemSlot.index] <= 0)
            {
                itensHeld[itemSlot.index] = "";
            }

            GameMenu.instance.ShowItens();
        }
        else
        {
            Debug.LogError($"Couldn't find {itemToRemove}");
        }
    }
}
