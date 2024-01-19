using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class InventoryUIPanel : MonoBehaviour
{
    [SerializeField]List<InventoryItemUI> inventoryItems;

    public UnityEvent<InventoryItem> OnItemDrop;
    public UnityEvent<InventoryItem> OnItemCraftClick; 

    public void AssignItem(InventoryItem item)
    {
        var emptySlot = GetFirstEmptySlot();
        emptySlot.AssignItem(item);
    }
    
    public void RemoveItem(InventoryItem item)
    {
    }

    public void DropItem(InventoryItem item)
    {
        RemoveItem(item);
        OnItemDrop.Invoke(item);
    }

    /// <summary>
    /// Get first ui slot without assigned item to it
    /// </summary>
    /// <returns>Empty ui slot or null if inventory is full</returns>
    public InventoryItemUI GetFirstEmptySlot()
    {
        return inventoryItems.Where(x => x.IsEmpty).FirstOrDefault();
    }

    public void MoveItemToCraft(InventoryItemUI item)
    {
        OnItemCraftClick.Invoke(item.ItemStored);
    }
}
