using Photon.Pun;
using UnityEngine;

public class InteractionManager : MonoBehaviourPun
{

    #region variables

    private float _interactionDistance = 3.0f;
    private PhotonView _photonView;
    private bool _once = true;

    private GameManager _gameManagerInstance;
    private TradePanelManager _tradePanelManagerInstance;
    private InteractionPanelManager _interactionPanelManagerInstance;

    #endregion

    #region Unity Functions

    private void Start()
    {
        _gameManagerInstance = GameManager.Instance;
        _interactionPanelManagerInstance = InteractionPanelManager.Instance;
        _tradePanelManagerInstance = TradePanelManager.Instance;
        
    }

    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            FindNearbyPlayerWithDistance();
        }
    }

    #endregion
    
    void FindNearbyPlayerWithDistance()
    {
        if (photonView.IsMine)
        {
            bool playerFound = false;
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _interactionDistance);
            foreach (var hitCollider in hitColliders)
            {
                PhotonView hitPhotonView = hitCollider.transform.parent.GetComponent<PhotonView>();
                TradeManager tradeManager = hitCollider.transform.parent.GetComponent<TradeManager>();

                if (hitPhotonView != null && tradeManager && !hitPhotonView.IsMine)
                {
                    playerFound = true;
                    _gameManagerInstance.currentInteractedPlayer = hitPhotonView.gameObject;
                    break;
                }
            }
            if (playerFound && _once)
            {
                _tradePanelManagerInstance.OpenTradePanels();
                _interactionPanelManagerInstance.OpenPlayerInteractionPanel();
                _once = false;
            }
            else if (!playerFound && !_once && _gameManagerInstance.currentInteractedPlayer)
            {
                _tradePanelManagerInstance.CloseTradePanels();
                _interactionPanelManagerInstance.CloseInteractionPanels();
                InspectPanelManager.Instance.CloseInspectPanels();
                _gameManagerInstance.currentInteractedPlayer = null;
                _once = true;
            }
        }
    }
}