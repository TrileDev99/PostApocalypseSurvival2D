using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> slots = new List<InventorySlot>();

    public void AddItem(ItemData itemData, int amount)
    {
   
        InventorySlot slot = slots.Find(s => s.item == itemData);

        if (slot != null)
        {
            slot.quantity += amount;
        }
        else
        {
            slots.Add(new InventorySlot(itemData, amount));
        }

        Debug.Log($"Added {amount}x {itemData.itemName}");
        InventoryUI.Instance.Refresh(this); // cập nhật UI
    }
}
