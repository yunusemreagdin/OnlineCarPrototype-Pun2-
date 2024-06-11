using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryManager : MonoBehaviour
{
    
    #region Variables
    
    #region Singleton
    public static UIInventoryManager Instance;
    #endregion

    #region Prefabs
    public GameObject uiItemPrefab;
    public GameObject uiTradePrefab;
    #endregion

    #region Transforms
    public Transform mainMenuTransform;
    public Transform inspectTransform;
    public Transform tradePanelTransform;
    #endregion

    #region Components
    public CarInspect carInspect;
    #endregion

    public TextMeshProUGUI moneyUI;
    
    #endregion
    

    #region UnityMethods
    
    private void Awake()
    {
        if (Instance != null)
        {
           Destroy(Instance);
        }

        Instance = this;
    }
    #endregion

    #region InventoryManagement
    public void InitializeMainMenu(Inventory inventory)
    {
        foreach (var i in inventory.inventoryList)
        {
            GameObject uiItem = Instantiate(uiItemPrefab,mainMenuTransform);
            UIInventoryItem uiInventoryItem = uiItem.GetComponent<UIInventoryItem>();
            uiInventoryItem.item = i;
            uiInventoryItem.Initialize();
        }
    }
    
    public void InitializeInspect(Inventory inventory)
    {
        for (int i = 0; i < inspectTransform.childCount; i++)
        {
            Destroy(inspectTransform.GetChild(i));
        }
        foreach (var i in inventory.inventoryList)
        {
            GameObject uiItem = Instantiate(uiItemPrefab,inspectTransform);
            UIInventoryItem uiInventoryItem = uiItem.GetComponent<UIInventoryItem>();
            Destroy(uiItem.GetComponent<Button>());
            uiInventoryItem.item = i;
            uiInventoryItem.Initialize();
        }
    }
    
    public void InitializeTrade(Inventory inventory)
    {
        foreach (var i in inventory.inventoryList)
        {
            GameObject uiItem = Instantiate(uiTradePrefab,tradePanelTransform);
            uiItem.GetComponent<UITradeItem>().item = i;
            uiItem.GetComponent<UITradeItem>().Initialize();
        }
    }
    #endregion

    #region Utility
    public void DestroyChildren(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Destroy(parent.GetChild(i).gameObject);
        }
    }
    
    public void ClearInventory()
    {
        DestroyChildren(mainMenuTransform);
    }
    
    public void ClearInspect()
    {
       DestroyChildren(inspectTransform);
    }
    
    public void ClearTrade()
    {
       DestroyChildren(tradePanelTransform);
    }
    #endregion
    
}