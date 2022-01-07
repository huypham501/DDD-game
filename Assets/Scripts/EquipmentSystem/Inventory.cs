using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject itemCell;
    private List<Item> listItem;
    public static Inventory instance;
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
        // Or load from save
        listItem = new List<Item>();
        initUIInventory();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void addItem(Item item)
    {
        listItem.Add(item);
        notifyAddItemUIInventory(item);
    }
    private void initUIInventory()
    {
        GameObject gameObjectTemp;
        foreach (Item item in listItem)
        {
            gameObjectTemp = Instantiate(itemCell, transform) as GameObject;
            gameObjectTemp.GetComponent<Image>().sprite = item.sprite_Front_default;
        }
    }
    private void notifyAddItemUIInventory(Item item)
    {
        GameObject gameObjectTemp;
        gameObjectTemp = Instantiate(itemCell, transform) as GameObject;
        gameObjectTemp.GetComponent<Image>().sprite = item.sprite_Front_default;
    }
}
