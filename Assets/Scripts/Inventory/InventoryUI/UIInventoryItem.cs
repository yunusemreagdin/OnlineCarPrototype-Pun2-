using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    #region Variables
    public Item item;
    public Image image;
    public TextMeshProUGUI itemName;
    #endregion

    #region Unity Methods
    public void Initialize()
    {
        image.sprite = item.itemImage;
        itemName.text = item.itemName;
    }
    #endregion

    #region Button Methods
    public void ButtonClick()
    {
        if (GameManager.Instance.player.transform.childCount > 0)
        {
            PhotonNetwork.Destroy(GameManager.Instance.player.transform.GetChild(0).gameObject);
        }
        GameManager.Instance.RccPhotonDemo.Spawn(item.itemPrefab.name);
        InventoryPanelManager.Instance.OpenInventoryButton();
        InventoryPanelManager.Instance.CloseInventoryPanel();
    }
    #endregion
}