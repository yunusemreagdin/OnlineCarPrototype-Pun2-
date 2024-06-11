using System;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradeRequestPanelController : MonoBehaviour
{
    #region Variables
    public Image image;
    public TextMeshProUGUI offerPrice;
    public TextMeshProUGUI carPrice;
    public TextMeshProUGUI carName;
    public Item item;
    public TextMeshProUGUI carModel;
    public TextMeshProUGUI carYear;
    public TextMeshProUGUI carMileage;
    public TextMeshProUGUI carColor;
    public TextMeshProUGUI carEnginePower;
    public TextMeshProUGUI carMaxSpeed;
    private GameManager _gameManagerInstance;
    private TradePanelManager _tradePanelManagerInstance;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _gameManagerInstance = GameManager.Instance;
        _tradePanelManagerInstance = TradePanelManager.Instance;
    }
    #endregion

    #region Initialization Methods
    public void Initialize(Item item, int offerPrice)
    {
        this.item = item;
        image.sprite = item.itemImage;
        carPrice.text = item.itemPrice.ToString();
        carName.text = item.itemName;
        this.offerPrice.text = "Offer Price:     " + offerPrice;
        carModel.text = $"Model: {item.itemModel}";
        carYear.text = $"Year: {item.itemYear}";
        carMileage.text = $"Mileage: {item.itemMileage}";
        carColor.text = $"Color: {item.itemColor}";
        carEnginePower.text = $"Engine: {item.itemEnginePower}";
        carMaxSpeed.text = $"Max Speed: {item.itemMaxSpeed}";
    }
    #endregion

    #region Trade Offer Response Methods
    public void AcceptTradeOffer()
    {
        _tradePanelManagerInstance.CloseTradePanels();
        _gameManagerInstance.player.GetComponent<TradeManager>().AcceptResponse(
            _gameManagerInstance.player.GetComponent<PhotonView>().ViewID.ToString(),
            _gameManagerInstance.currentInteractedPlayer.GetComponent<PhotonView>().ViewID.ToString(), 
            item.id, Int32.Parse(offerPrice.text));
    }

    public void RejectTradeOffer()
    {
        _tradePanelManagerInstance.CloseTradeOfferPanel();
        _gameManagerInstance.player.GetComponent<TradeManager>().RejectResponse(
            _gameManagerInstance.currentInteractedPlayer.GetComponent<PhotonView>().ViewID.ToString()
        );
    }
    #endregion
}