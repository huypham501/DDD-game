using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItemCell : MonoBehaviour
{
    public GameObject itemImage;

    private void Awake()
    {

    }
    public void setItemImage(Sprite ortherSprite)
    {
        itemImage.GetComponent<Image>().sprite = ortherSprite;
    }
    public int getIndex()
    {
        return transform.GetSiblingIndex();
    }
}
