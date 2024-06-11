using UnityEngine;

public class InspectPanelManager : MonoBehaviour
{
    #region Singleton
    public static InspectPanelManager Instance;

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
    private UIInventoryManager _uiInventoryManagerInstance;
    private InteractionPanelManager _interactionPanelManagerInstance;
    
    public GameObject inspectInventoryPanel;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _uiInventoryManagerInstance = UIInventoryManager.Instance;
        _interactionPanelManagerInstance = InteractionPanelManager.Instance;
    }
    #endregion

    #region Panel Control Methods
    public void OpenInspectInventoryPanel()
    {
        _uiInventoryManagerInstance.InitializeInspect(GameManager.Instance.currentInteractedPlayer.GetComponent<Inventory>());
        inspectInventoryPanel.SetActive(true);
        _interactionPanelManagerInstance.CloseInteractionPanels();
    }

    public void CloseInspectInventoryPanel()
    {
        _uiInventoryManagerInstance.ClearInspect();
        inspectInventoryPanel.SetActive(false);
    }

    public void CloseInspectPanels()
    {
        CloseInspectInventoryPanel();
    }
    #endregion
}