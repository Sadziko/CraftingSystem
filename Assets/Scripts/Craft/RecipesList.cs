using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Craft/RecipesList")]
public class RecipesList : ScriptableObject
{
    public List<CraftingRecipe> craftingRecipes;
}
