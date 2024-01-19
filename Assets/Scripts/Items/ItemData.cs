using UnityEngine;

[CreateAssetMenu(menuName = ("Items/ItemData"))]
public class ItemData : ScriptableObject
{
    public int ID;
    public string Name;
    public Sprite Icon;

    //how item looks when dropped in world
    public GameObject prefabWorld;
}