using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject currentInteractedPlayer;
    public RCC_PhotonDemo RccPhotonDemo;
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        
        Instance = this;
    }
}