using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemCell : MonoBehaviour
{
    public GameObject itemImage;
    public void setItemImage(Sprite ortherSprite)
    {
        itemImage.GetComponent<Image>().sprite = ortherSprite;
    }
}
