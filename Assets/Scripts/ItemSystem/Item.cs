using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string id;
    public string itemName;
    public Sprite itemImage;
    public GameObject itemPrefab;
    public int itemPrice;
    
    public string itemModel;
    public int itemYear;
    public int itemMileage;
    public string itemColor;
    public int itemEnginePower;
    public int itemMaxSpeed;
}