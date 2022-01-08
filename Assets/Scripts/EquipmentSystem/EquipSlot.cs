using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour, IDropHandler
{
    public GameObject equipCellImage;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<ItemDragDrop>().setEquip();
            equipItem(eventData.pointerDrag.GetComponent<Image>().sprite);
        }
    }
    private void equipItem(Sprite otherSprite)
    {
        equipCellImage.GetComponent<Image>().sprite = otherSprite;
    }
}
