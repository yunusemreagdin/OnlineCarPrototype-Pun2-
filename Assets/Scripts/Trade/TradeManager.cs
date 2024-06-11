using System;
using Photon.Pun;
using UnityEngine;


public class TradeManager : MonoBehaviourPun
{
    
    #region Variables
    
    #region Trade Settings
    public bool isTradeOffer;
    #endregion

   
    #region Managers
    private TradePanelManager _tradePanelManager;
    private InventoryManager _inventoryManager;
    private InteractionPanelManager _interactionPanelManager;
    #endregion
    #endregion
    
    #region Unity Methods

    private void Start()
    {
        _tradePanelManager = TradePanelManager.Instance;
        _inventoryManager = InventoryManager.Instance;
        _interactionPanelManager = InteractionPanelManager.Instance;
    }

    #endregion
    
    #region SendOfferFunctions
    
    public void SetTradeOffer(bool newValue, string itemID, int offerPrice)
    {
        photonView.RPC(nameof(RPC_SendTradeOffer), RpcTarget.All, newValue, itemID, offerPrice);
    }

    [PunRPC]
    public void RPC_SendTradeOffer(bool newValue,string itemID, int offerPrice)
    {
        
        isTradeOffer = newValue;
        if (photonView.IsMine)
        {
            if (isTradeOffer)
            {
                foreach (var i in GetComponent<Inventory>().inventoryList)
                {
                    if (i.id == itemID)
                    {
                        _tradePanelManager.OpenTradeOfferPanel(i,offerPrice);
                        break;
                    }
                }
            }
        }
    }
    
    #endregion

    #region Accept Response

    public void AcceptResponse(string carOwnerID, string customerID, string itemID, int price)
    {
        photonView.RPC(nameof(RPC_AcceptResponse), RpcTarget.All, carOwnerID,customerID,itemID,price);
    }
    
    [PunRPC]
    
    public void RPC_AcceptResponse(string carOwnerID, string customerID, string itemID, int price)
    {
        PhotonView[] allPlayers = FindObjectsOfType<PhotonView>();
        foreach (PhotonView player in allPlayers)
        {
            if (player.ViewID.ToString() == carOwnerID)
            {
                _inventoryManager.RemoveItemWithID(player.GetComponent<Inventory>(),itemID);
                player.GetComponent<Inventory>().Money += price;
            }
        }

        foreach (PhotonView player in allPlayers)
        {
            if (player.ViewID.ToString() == customerID)
            {
                if (player.IsMine)
                {
                    _tradePanelManager.ResponsePanelAccepted();
                }
                _inventoryManager.AddItemWithID(player.GetComponent<Inventory>(),itemID);
                player.GetComponent<Inventory>().Money -= price;
            }
        }
    }

    #endregion

    #region Reject Response

    public void RejectResponse(string customerID)
    {
        photonView.RPC(nameof(RPC_RejectResponse), RpcTarget.All, customerID);
    }
    
    [PunRPC]
    
    public void RPC_RejectResponse(string customerID)
    {
        PhotonView[] allPlayers = FindObjectsOfType<PhotonView>();
        
        foreach (PhotonView player in allPlayers)
        {
            if (player.ViewID.ToString() == customerID)
            {
                if (player.IsMine)
                {
                    _tradePanelManager.ResponsePanelRejected();
                    _interactionPanelManager.CloseInteractionPanels();
                }
            }
        }
    }

    #endregion
    
    
    
}