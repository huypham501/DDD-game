using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour, IDropHandler
{
    public GameObject equipCellImage;
    public ItemTypeEnum itemEquipTypeEnum;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && !CharacterController.instance.isDead)
        {
            ItemDragDrop itemDragDropTemp = eventData.pointerDrag.GetComponent<ItemDragDrop>();
            if (itemDragDropTemp != null && itemDragDropTemp.getItem().itemTypeEnum == itemEquipTypeEnum)
            {
                EquipmentSystem.instance.equipItem(itemDragDropTemp.getItem());
                itemDragDropTemp.setEquip();
                equipItem(eventData.pointerDrag.GetComponent<Image>().sprite);
            }
        }
    }
    private void equipItem(Sprite otherSprite)
    {
        equipCellImage.GetComponent<Image>().sprite = otherSprite;
    }
}
