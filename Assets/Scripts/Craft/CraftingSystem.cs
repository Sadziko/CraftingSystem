using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CraftingSystem : MonoBehaviour
{
    [SerializeField] RecipesList recipesList;
    [SerializeField] List<CraftItemUI> craftItems;
    [SerializeField] CraftItemUI resultItem;

    public UnityEvent<InventoryItem> OnCraftSuccesful;
    public UnityEvent<InventoryItem> OnCraftFail;

    public UnityEvent<InventoryItem> OnReturnToinventory;

    public void OnCraftButton()
    {
        if(CraftItemsEmpty()) return;

        List<ItemData> items = new List<ItemData>();
        foreach (var item in craftItems)
        {
            items.Add(item.ItemStored.ItemData);
        }
        CraftItem(items);
    }


    public void CraftItem(List<ItemData> itemsUsed)
    {
        foreach(CraftingRecipe recipe in recipesList.craftingRecipes)
        {
            if (ItemsMatched(itemsUsed, recipe))
            {
                Debug.Log("Craft succesful of " + recipe.Result);
                OnCraftSuccesful.Invoke(new InventoryItem()
                {
                    ItemData = recipe.Result
                });
            }

        }
    }

    public void AssignItem(InventoryItem item)
    {
        var emptySlot = GetFirstEmptySlot();
        emptySlot.AssignItem(item);
    }

    /// <summary>
    /// Get first ui slot without assigned item to it
    /// </summary>
    /// <returns>Empty ui slot or null if inventory is full</returns>
    public CraftItemUI GetFirstEmptySlot()
    {
        return craftItems.Where(x => x.IsEmpty).FirstOrDefault();
    }

    /// <summary>
    /// Clears data from craft item slots, doesnt return them into inventory
    /// </summary>
    public void RemoveCraftItems()
    {
        foreach(var item in craftItems)
        {
            item.RemoveItem();
        }
    }

    public void ReturnToInventory(InventoryItem item) {
        OnReturnToinventory.Invoke(item);
    }

    /// <summary>
    /// Checks if items match recipe requirements
    /// </summary>
    /// <param name="itemsUsed">Items that will be checked with recpie requirements</param>
    /// <param name="recipe">Recipe to check</param>
    /// <returns>True if requirements are fullfiled</returns>
    private bool ItemsMatched(List<ItemData> itemsUsed, CraftingRecipe recipe)
    {
        return recipe.Ingredients.OrderBy(x => x.ID).SequenceEqual(itemsUsed.OrderBy(x => x.ID));
    }

    private bool CraftItemsEmpty()
    {
        foreach (var item in craftItems)
        {
            if (item.IsEmpty)
                return true;
        }

        return false;
    }
}
