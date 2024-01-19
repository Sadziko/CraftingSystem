using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Craft/CraftingRecipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemData> Ingredients;
    public ItemData Result;

    [Range(0.1f, 100f)]
    public float PercentageChanceSuccess;
}
