using System.Collections;
using System.Collections.Generic;

public class InventoryItemUI : ItemUI
{
    InventoryUIPanel _inventoryPanel;

    private void Awake()
    {
        if(_defaultSprite != null)
        {
            SetSprite(_defaultSprite);
        }
        else
        {
            _defaultSprite = _sprite.sprite;
        }

        _inventoryPanel = GetComponentInParent<InventoryUIPanel>();
    }


    public void MoveToCraft()
    {
        _inventoryPanel.MoveItemToCraft(this);
        RemoveItem();
    }


}
