
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData itemData;
    public int amount = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inv = other.GetComponent<Inventory>();

            if (inv != null)
            {
                inv.AddItem(itemData, amount);
                Destroy(gameObject);
            }
        }
    }
}
