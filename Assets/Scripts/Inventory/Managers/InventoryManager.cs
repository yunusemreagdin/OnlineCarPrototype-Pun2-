using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    #region Singleteon
    
    public static InventoryManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        
        Instance = this;
    }
    #endregion

    #region Variables
    
    public List<Item> allItems = new List<Item>();
    
    #endregion
    
    public void AddItemWithID(Inventory inventory, string itemID)
    {
        foreach (var item in allItems)
        {
            if (item.id == itemID )
            {
                inventory.AddItem(item);
            }
        }
    }
    public void RemoveItemWithID(Inventory inventory,string itemID)
    {
        foreach (var item in allItems)
        {
            if (item.id == itemID )
            {
                inventory.RemoveItem(item);
            }
        }
    }
    
}