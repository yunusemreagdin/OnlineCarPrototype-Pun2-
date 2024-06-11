using UnityEngine;

public class UIInventory : MonoBehaviour
{
    private void OnDisable()
    {
        UIInventoryManager.Instance.ClearInventory();
    }
}
