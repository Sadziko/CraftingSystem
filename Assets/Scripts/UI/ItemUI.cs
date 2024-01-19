using UnityEngine;
using UnityEngine.UI;

public abstract class ItemUI : MonoBehaviour
{
    protected InventoryItem _itemStored;
    public InventoryItem ItemStored => _itemStored;

    protected bool _isEmpty = true;
    public bool IsEmpty => _isEmpty;

    [SerializeField] protected Image _sprite;
    [SerializeField] protected Sprite _defaultSprite;


    public virtual void AssignItem(InventoryItem item)
    {
        if (item == null) return;

        _itemStored = item;
        _isEmpty = false;
        SetSprite(item.ItemData.Icon);
    }

    public virtual void RemoveItem()
    {
        _isEmpty = true;
        _itemStored = null;
        SetSprite(_defaultSprite);
    }

    public void SetSprite(Sprite sprite)
    {
        _sprite.sprite = sprite;
    }
}
