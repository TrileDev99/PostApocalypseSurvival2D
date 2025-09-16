using UnityEngine;
using UnityEngine.UI;
using System.Text;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;
    public TextMeshProUGUI inventoryText;

    void Awake()
    {
        Instance = this;
    }

    public void Refresh(Inventory inv)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var slot in inv.slots)
        {
            sb.AppendLine($"{slot.item.itemName}: {slot.quantity}");
        }
        inventoryText.text = sb.ToString();
    }
}
