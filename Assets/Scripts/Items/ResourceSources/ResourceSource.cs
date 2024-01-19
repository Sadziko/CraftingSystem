using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSource : MonoBehaviour
{
    [SerializeField] ResourceConfig resourcesToDrop;

    public ItemData GatherResources()
    {
        var resource = resourcesToDrop.Collect();
        return resource;
    }
}
