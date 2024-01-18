using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Resources/ResourceConfig")]
public class ResourceConfig : ScriptableObject
{
    public ItemData itemToDrop;

    public ItemData Collect()
    {
        return itemToDrop;
    }
}
