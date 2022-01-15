using UnityEngine;

public class InventoryButtons : MonoBehaviour
{
    // Inventory system, does not pause game when open
    public GameObject InventoryUI;

    public void OpenClose()
    {
        if (!InventoryUI.activeInHierarchy)
        {
            InventoryUI.SetActive(true);
        }
        else
        {
            InventoryUI.SetActive(false);
        }
    }
}
