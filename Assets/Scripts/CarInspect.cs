using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarInspect : MonoBehaviour
{
    #region Variables
    public Item item;
    public Image image;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemPrice;
    public TMP_InputField offerPrice;
    public TextMeshProUGUI itemModel;
    public TextMeshProUGUI itemYear;
    public TextMeshProUGUI itemMileage;
    public TextMeshProUGUI itemColor;
    public TextMeshProUGUI itemEnginePower;
    public TextMeshProUGUI itemMaxSpeed;
    private GameManager _gameManagerInstance;
    private TradePanelManager _tradePanelManager;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _gameManagerInstance = GameManager.Instance;
        _tradePanelManager = TradePanelManager.Instance;
    }
    #endregion

    #region Initialization Methods
    public void Initialize()
    {
        image.sprite = item.itemImage;
        itemName.text = item.itemName;
        itemPrice.text = $"Price: {item.itemPrice}";
        itemModel.text = $"Model: {item.itemModel}";
        itemYear.text = $"Year: {item.itemYear}";
        itemMileage.text = $"Mileage: {item.itemMileage}";
        itemColor.text = $"Color: {item.itemColor}";
        itemEnginePower.text = $"Engine: {item.itemEnginePower}";
        itemMaxSpeed.text = $"Max Speed: {item.itemMaxSpeed}";
    }
    #endregion

    #region Trade Offer Methods
    public void SendTradeOffer()
    {
        int offerPriceValue = Int32.Parse(offerPrice.text);
        Inventory playerInventory = _gameManagerInstance.player.GetComponent<Inventory>();
        if (playerInventory._money >= offerPriceValue)
        {
            string selectedItemID = item.id;
            _gameManagerInstance.currentInteractedPlayer.GetComponent<TradeManager>().SetTradeOffer(true, selectedItemID, offerPriceValue);
            _tradePanelManager.CloseOnlyTradePanels();
            _tradePanelManager.OpenWaitingResponsePanel();
        }
        else
        {
            _tradePanelManager.OpenErrorInsuffPanel();
        }
        
    }
    #endregion
}