using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    public Item swordItem;
    public GameObject sword;
    public Item armorItem;
    public GameObject bodyClothesBack;
    public GameObject bodyClothesFront;
    public GameObject bodyClothesLeft;
    public GameObject bodyClothesRight;
    public GameObject leftShoesBack;
    public GameObject leftShoesFront;
    public GameObject leftShoesLeft;
    public GameObject leftShoesRight;
    public GameObject RightShoesBack;
    public GameObject RightShoesFront;
    public GameObject RightShoesLeft;
    public GameObject RightShoesRight;
    public Item helmetItem;
    public GameObject hatBack;
    public GameObject hatFront;
    public GameObject hatLeft;
    public GameObject hatRight;
    public static EquipmentSystem instance;
    #region Singleton
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion
    private void updateCharacterStats(Stats removeItemStats, Stats equipItemStats)
    {
        if (removeItemStats == null)
        {
            CharacterController.instance.characterStats = CharacterController.instance.characterStats + equipItemStats;
        }
        else
        {
            CharacterController.instance.characterStats = CharacterController.instance.characterStats + equipItemStats - removeItemStats;
        }
        UIEquipmentController.instance.updateUIStats();
        CharacterController.instance.updateMaxHealthBar();
    }
    private void equipArmor(Item item)
    {
        if (armorItem == null)
        {
            updateCharacterStats(null, item.itemStats);
        }
        else
        {
            updateCharacterStats(armorItem.itemStats, item.itemStats);
        }
        armorItem = item;
        bodyClothesFront.transform.GetComponent<SpriteRenderer>().sprite = item.sprite_Front_default;
        bodyClothesBack.transform.GetComponent<SpriteRenderer>().sprite = item.sprite_Back;
        bodyClothesLeft.transform.GetComponent<SpriteRenderer>().sprite = item.sprite_Left;
        bodyClothesRight.transform.GetComponent<SpriteRenderer>().sprite = item.sprite_Right;
    }
    private void equipHelmet(Item item)
    {
        if (helmetItem == null)
        {
            updateCharacterStats(null, item.itemStats);
        }
        else
        {
            updateCharacterStats(helmetItem.itemStats, item.itemStats);
        }
        helmetItem = item;
        hatFront.transform.GetComponent<SpriteRenderer>().sprite = item.sprite_Front_default;
        hatBack.transform.GetComponent<SpriteRenderer>().sprite = item.sprite_Back;
        hatLeft.transform.GetComponent<SpriteRenderer>().sprite = item.sprite_Left;
        hatRight.transform.GetComponent<SpriteRenderer>().sprite = item.sprite_Right;
    }
    private void equipSword(Item item)
    {
        if (swordItem == null)
        {
            updateCharacterStats(null, item.itemStats);
        }
        else
        {
            updateCharacterStats(swordItem.itemStats, item.itemStats);
        }
        swordItem = item;
        sword.transform.GetComponent<SpriteRenderer>().sprite = item.sprite_Front_default;
    }
    public void equipItem(Item item)
    {
        switch (item.itemTypeEnum)
        {
            case ItemTypeEnum.Armor:
                equipArmor(item);
                break;
            case ItemTypeEnum.Helmet:
                equipHelmet(item);
                break;
            case ItemTypeEnum.Sword:
                equipSword(item);
                break;
            default:
                Debug.Log("Cannot detect type of object");
                break;
        };
        // SpriteRenderer spriteRendererTemp = testGameObject.transform.GetComponent<SpriteRenderer>();
        // spriteRendererTemp.sprite = item.sprite;
    }
}
