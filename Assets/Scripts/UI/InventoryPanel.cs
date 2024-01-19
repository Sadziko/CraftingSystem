using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField]List<InventoryItemUI> inventoryItems;

    public UnityEvent<InventoryItem> OnItemRemoved;

    private void OnEnable()
    {
        
    }

    public void AssignItem(InventoryItem item)
    {
        var emptySlot = GetFirstEmptySlot();
        emptySlot.AssignItem(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        OnItemRemoved.Invoke(item);
    }

    /// <summary>
    /// Get first ui slot without assigned item to it
    /// </summary>
    /// <returns>Empty ui slot or null if inventory is full</returns>
    public InventoryItemUI GetFirstEmptySlot()
    {
        return inventoryItems.Where(x => x.IsEmpty).FirstOrDefault();
    }
}
