using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    InventoryItem _itemStored;

    private bool _isEmpty = true;
    public bool IsEmpty => _isEmpty;

    [SerializeField] private Image _sprite;
    [SerializeField] Sprite _defaultSprite;
    InventoryPanel _inventoryPanel;

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

        _inventoryPanel = GetComponentInParent<InventoryPanel>();
    }

    public void AssignItem(InventoryItem item)
    {
        _itemStored = item;
        _isEmpty = false;
        SetSprite(item.ItemData.Icon);
    }

    public void RemoveItem()
    {
        _inventoryPanel.RemoveItem(_itemStored);
        _isEmpty = true;
        _itemStored = null;
        SetSprite(_defaultSprite);
    }

    public void SetSprite(Sprite sprite)
    {
        _sprite.sprite = sprite;
    }

}
