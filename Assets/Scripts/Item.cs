using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;

    [Header("Item Details")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;

    [Header("Item Details")]
    public int amountToChange;
    public bool affectHP;
    public bool affectMP;
    public bool affectStrenght;

    [Header("Weapon/Armor Details")]
    public int weaponStrenght;
    public int armorStrenght;
    void Start()
    {

    }

    void Update()
    {

    }
}
