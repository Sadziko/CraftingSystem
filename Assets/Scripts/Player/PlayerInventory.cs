using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInventory : MonoBehaviour
{
     public List<InventoryItem> items = new List<InventoryItem>();

    public UnityEvent<InventoryItem> OnItemAdd;

    public void AddToInventory(ItemData item)
    {
        var inventoryItem = new InventoryItem()
        {
            ItemData = item
        };
        items.Add(inventoryItem);

        OnItemAdd.Invoke(inventoryItem);
    }
}


[Serializable]
public class InventoryItem
{
    public ItemData ItemData;
}
