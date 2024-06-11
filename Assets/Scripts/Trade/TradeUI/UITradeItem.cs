using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITradeItem : MonoBehaviour
{
    #region Variables
    public Item item;
    public Image image;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemPrice;
    public TextMeshProUGUI itemModel;
    public TextMeshProUGUI itemYear;
    public TextMeshProUGUI itemMileage;
    public TextMeshProUGUI itemColor;
    public TextMeshProUGUI itemEnginePower;
    public TextMeshProUGUI itemMaxSpeed;
    private UIInventoryManager _uiInventoryManager;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _uiInventoryManager = UIInventoryManager.Instance;
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

    #region Item Selection Methods
    public void SelectItem()
    {
        _uiInventoryManager.carInspect.item = item;
        _uiInventoryManager.carInspect.Initialize();
    }
    #endregion
}