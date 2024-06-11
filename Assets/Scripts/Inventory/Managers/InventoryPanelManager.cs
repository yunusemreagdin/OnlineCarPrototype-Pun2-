using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelManager : MonoBehaviour
{
    #region Variables
    #region Singleton
    public static InventoryPanelManager Instance;
    #endregion

    #region Managers
    private UIInventoryManager _uiInventoryManager;
    private GameManager _gameManagerInstance;
    #endregion

    #region UI Elements
    public GameObject mainMenuPanel;
    public Button inventoryOpenButton;
    #endregion
    #endregion

    #region Unity Methods
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        
        Instance = this;
    }

    private void Start()
    {
        _uiInventoryManager = UIInventoryManager.Instance;
        _gameManagerInstance = GameManager.Instance;
    }
    #endregion

    #region Panel Management
    public void OpenInventoryPanel() => mainMenuPanel.SetActive(true);

    public void CloseInventoryPanel() => mainMenuPanel.SetActive(false);

    public void ToggleMainMenuPanel()
    {
        _uiInventoryManager.InitializeMainMenu(_gameManagerInstance.player.GetComponent<Inventory>());
        mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
    }

    public void OpenInventoryButton()
    {
        inventoryOpenButton.gameObject.SetActive(true);
    }
    #endregion
}