using UnityEngine;

public class InventoryButtons : MonoBehaviour
{
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
