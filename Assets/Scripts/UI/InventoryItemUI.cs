using System.Collections;
using System.Collections.Generic;

public class InventoryItemUI : ItemUI
{
    InventoryUIPanel _inventoryPanel;

    private void Awake()
    {
        _inventoryPanel = GetComponentInParent<InventoryUIPanel>();
    }


    public void Dropitem()
    {
        if (_inventoryPanel == null) return;

        _inventoryPanel.DropItem(ItemStored);
        RemoveItem();
    }

    public void MoveToCraft()
    {
        if (_inventoryPanel == null) return;

        _inventoryPanel.MoveItemToCraft(this);
        RemoveItem();
    }


}
