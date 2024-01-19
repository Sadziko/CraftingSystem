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

    public void RemoveFromInventory(InventoryItem item)
    {
        items.Remove(item);
        ThrowItem(item.ItemData);
    }

    public void ThrowItem(ItemData item)
    {
        var go = Instantiate(item.prefabWorld, transform.position + new Vector3(0,0,2), Quaternion.identity);

        go.GetComponent<Rigidbody>().AddForce(Vector3.forward * 5f, ForceMode.Impulse);
    }
}


[Serializable]
public class InventoryItem
{
    public ItemData ItemData;
}
