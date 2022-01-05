using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    public GameObject sword;
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
    // Start is called before the first frame update
    void Start()
    {
        // SpriteRenderer spriteRendererTemp = testGameObject.transform.GetComponent<SpriteRenderer>();
        // spriteRendererTemp.sprite = transforms[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void equipItem(Item item)
    {
        // SpriteRenderer spriteRendererTemp = testGameObject.transform.GetComponent<SpriteRenderer>();
        // spriteRendererTemp.sprite = item.sprite;
    }
}
