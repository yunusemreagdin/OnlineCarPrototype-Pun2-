using System.Collections;
using TMPro;
using UnityEngine;

public class TradePanelManager : MonoBehaviour
{
    #region Singleton
    public static TradePanelManager Instance;

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
    public GameObject allTradePanels;
    public GameObject tradePanel;
    public GameObject tradeOfferPanel;
    public GameObject carInspectPanel;
    public GameObject waitingResponsePanel;
    public GameObject errorInsuffPanel;
    private GameManager _gameManagerInstance;
    private UIInventoryManager _uiInventoryManager;
    private InteractionPanelManager _interactionPanelManager;
    #endregion

    #region Unity Methods

    private void Start()
    {
        _gameManagerInstance = GameManager.Instance;
        _uiInventoryManager = UIInventoryManager.Instance;
        _interactionPanelManager = InteractionPanelManager.Instance;
    }

    #endregion

    #region Inspect Inventory Panel Methods
    public void OpenTradePanel()
    {
        UIInventoryManager.Instance.InitializeTrade(GameManager.Instance.currentInteractedPlayer.GetComponent<Inventory>());
        tradePanel.SetActive(true);
        OpenCarInspectPanel();
        InteractionPanelManager.Instance.CloseInteractionPanels();
    }

    public void CloseTradePanel()
    {
        UIInventoryManager.Instance.ClearTrade();
        tradePanel.SetActive(false);
        CloseCarInspectPanel();
    }
    #endregion

    #region Trade Offer Panel Methods
    public void OpenTradeOfferPanel(Item item, int offerPrice)
    {
        _interactionPanelManager.CloseInteractionPanels();
        tradeOfferPanel.GetComponent<TradeRequestPanelController>().Initialize(item, offerPrice);
        tradeOfferPanel.SetActive(true);
    }

    public void CloseTradeOfferPanel()
    {
        tradeOfferPanel.SetActive(false);
    }
    #endregion

    #region Waiting Response Panel Methods
    public void OpenWaitingResponsePanel()
    {
        waitingResponsePanel.SetActive(true);
    }

    public void CloseWaitingResponsePanel()
    {
        waitingResponsePanel.SetActive(false);
        waitingResponsePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Waiting Response";
    }

    public void ResponsePanelAccepted()
    {
        waitingResponsePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Accepted";
        StartCoroutine(ClosePanel());
        
        IEnumerator ClosePanel()
        {
            yield return new WaitForSeconds(3);
            CloseWaitingResponsePanel();
        }   
    }

    public void ResponsePanelRejected()
    {
        waitingResponsePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Rejected";
        StartCoroutine(ClosePanel());
        
        IEnumerator ClosePanel()
        {
            yield return new WaitForSeconds(3);
            CloseWaitingResponsePanel();
        }
    }
    #endregion

    #region Trade Panels Methods
    public void OpenTradePanels()
    {
        allTradePanels.SetActive(true);
    }

    public void CloseTradePanels()
    {
        allTradePanels.SetActive(false);
        CloseCarInspectPanel();
        CloseTradeOfferPanel();
        CloseTradePanel();
        CloseWaitingResponsePanel();
    }

    public void CloseOnlyTradePanels()
    {
        CloseCarInspectPanel();
        CloseTradeOfferPanel();
        CloseTradePanel();
        CloseWaitingResponsePanel();
    }
    #endregion

    #region Car Inspect Panel Methods
    public void OpenCarInspectPanel()
    {
        carInspectPanel.SetActive(true);
        _uiInventoryManager.carInspect.item = _gameManagerInstance.currentInteractedPlayer.GetComponent<Inventory>().inventoryList[0];
        _uiInventoryManager.carInspect.Initialize();
    }

    public void CloseCarInspectPanel()
    {
        carInspectPanel.SetActive(false);
    }

    public void OpenErrorInsuffPanel()
    {
        errorInsuffPanel.SetActive(true);
        StartCoroutine(CloseErrorInsuffPanelAfterDelay());
    }
    
    public void CloseErrorInsuffPanel()
    {
        errorInsuffPanel.SetActive(false);
    }
    
    private IEnumerator CloseErrorInsuffPanelAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        CloseErrorInsuffPanel();
    }
    #endregion
}