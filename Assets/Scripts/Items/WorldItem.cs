using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    [SerializeField] ItemData itemGetOnPickUp;

    public ItemData ItemData => itemGetOnPickUp;

    public void OnPickup()
    {
        Destroy(gameObject);
    }
}
