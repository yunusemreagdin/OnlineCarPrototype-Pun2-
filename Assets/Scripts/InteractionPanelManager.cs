using UnityEngine;

public class InteractionPanelManager : MonoBehaviour
{
    
    public GameObject playerInteractionPanel;
    public GameObject interactionDetailsPanel;
    #region Singleteon

    public static InteractionPanelManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        
        Instance = this;
    }

    #endregion
   
   
    
    #region Information Panel Methods
    public void OpenPlayerInteractionPanel() => playerInteractionPanel.SetActive(true);
    public void ClosePlayerInteractionPanel() => playerInteractionPanel.SetActive(false);
    #endregion
    
    #region Trade and Inspect Panel Methods
    public void OpenInteractionDetailsPanel() => interactionDetailsPanel.SetActive(true);
    public void CloseInteractionDetailsPanel() => interactionDetailsPanel.SetActive(false);
    #endregion

    public void CloseInteractionPanels()
    {
        CloseInteractionDetailsPanel();
        ClosePlayerInteractionPanel();
    }
}
