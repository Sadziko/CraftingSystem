using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInventory : MonoBehaviour
{
     public List<InventoryItem> items = new List<InventoryItem>();    
    [SerializeField] GameObject EquipmentGameObject;

    [Header("Config")]
    [SerializeField] float throwForce = 5f;

    [Header("Events")]
    public UnityEvent<InventoryItem> OnItemAdd;

    public void OnEquipmentInput(CallbackContext callbackContext)
    {
        if (callbackContext.phase != UnityEngine.InputSystem.InputActionPhase.Started) return;

        EquipmentGameObject.SetActive(!EquipmentGameObject.activeInHierarchy);
    }

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
        //spawn with offset to prevent instant pickup
        var go = Instantiate(item.prefabWorld, transform.position + Vector3.forward * 2f, Quaternion.identity);

        go.GetComponent<Rigidbody>().AddForce(Vector3.forward * throwForce, ForceMode.Impulse);
    }
}


[Serializable]
public class InventoryItem
{
    public ItemData ItemData;
}
