using Photon.Pun;
using UnityEngine;

public class SetParent : MonoBehaviourPun
{
    #region Unity Methods
    private void Start()
    {
        SetPlayerAndCarIDs(out string playerID, out string carID);
        photonView.RPC(nameof(RPC_SetParent), RpcTarget.AllBuffered, carID, playerID);
    }
    #endregion

    #region RPC Method
    [PunRPC]
    public void RPC_SetParent(string carID, string playerID)
    {
        PhotonView[] allPlayers = FindObjectsOfType<PhotonView>();
        Transform playerTransform = null;
        
        foreach (PhotonView player in allPlayers)
        {
            if (player.ViewID.ToString() == playerID && !player.GetComponent<RCC_CarControllerV3>())
            {
                playerTransform = player.transform;
                break;
            }
        }
        
        foreach (PhotonView player in allPlayers)
        {
            if (player.ViewID.ToString() == carID && player.GetComponent<RCC_CarControllerV3>())
            {
                player.transform.parent = playerTransform;
                break;
            }
        }
    }
    #endregion

    #region Utility Methods
    private void SetPlayerAndCarIDs(out string playerID, out string carID)
    {
        playerID = "";
        carID = "";
        
        PhotonView[] allPlayers = FindObjectsOfType<PhotonView>();
        
        foreach (PhotonView player in allPlayers)
        {
            if (player.IsMine && !player.GetComponent<RCC_CarControllerV3>())
            {
                playerID = player.ViewID.ToString();
            }
        }
        
        foreach (PhotonView player in allPlayers)
        {
            if (player.IsMine && player.GetComponent<RCC_CarControllerV3>())
            {
                carID = player.ViewID.ToString();
            }
        }
    }
    #endregion
}