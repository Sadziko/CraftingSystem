using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInventory : MonoBehaviour
{
     public List<InventoryItem> items = new List<InventoryItem>();    
    [SerializeField] GameObject EquipmentGameObject;

    [Header("Config")]
    [SerializeField] float maxCapacity;
    [SerializeField] float throwForceOnDrop = 5f;

    [Header("Events")]
    public UnityEvent<InventoryItem> OnItemAdd;


    public void OnEquipmentInput(CallbackContext callbackContext)
    {
        if (callbackContext.phase != InputActionPhase.Started) return;

        EquipmentGameObject.SetActive(!EquipmentGameObject.activeInHierarchy);
    }

    public void AddToInventory(ItemData item)
    {
        if (items.Count >= maxCapacity) return;

        var inventoryItem = new InventoryItem()
        {
            ItemData = item
        };
        items.Add(inventoryItem);

        OnItemAdd.Invoke(inventoryItem);
    }

    public void DropItemInWorld(InventoryItem item)
    {
        ThrowItem(item.ItemData.prefabWorld);
        RemoveFromInventory(item);
    }

    public void RemoveFromInventory(InventoryItem item)
    {
        items.Remove(item);
    }

    public void RemoveFromInventory(int id)
    {
        RemoveFromInventory(items.Where(x => x.ItemData.ID == id).First());
    }

    /// <summary>
    /// Spawns item in world and applies force to it
    /// </summary>
    public void ThrowItem(GameObject prefab)
    {
        //spawn with offset to prevent instant pickup
        var go = Instantiate(prefab, transform.position + Vector3.forward * 2f, Quaternion.identity);
        go.GetComponent<Rigidbody>().AddForce(Vector3.forward * throwForceOnDrop, ForceMode.Impulse);
    }
}
