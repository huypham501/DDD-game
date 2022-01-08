using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name;
    public ItemTypeEnum itemTypeEnum;
    // default is only one sprite for a top down - 4 sprite
    public Sprite sprite_Front_default = null;
    public Sprite sprite_Back = null;
    public Sprite sprite_Left = null;
    public Sprite sprite_Right = null;
    public ItemTypeEnum GetItemTypeEnum()
    {
        return itemTypeEnum;
    }
}