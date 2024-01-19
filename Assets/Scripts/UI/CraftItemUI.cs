using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CraftItemUI : ItemUI
{
    CraftingSystem _craftingSystem;

    private void Awake()
    {
        _craftingSystem = GetComponentInParent<CraftingSystem>();
    }

    public void ReturnToInventory()
    {
        _craftingSystem.ReturnToInventory(ItemStored);
        RemoveItem();
    }
}
