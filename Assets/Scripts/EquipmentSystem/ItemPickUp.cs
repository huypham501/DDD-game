using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            pickUp();
        }
    }
    private void pickUp()
    {
        // if (EquipmentSystem.instance != null)
        // {
        //     EquipmentSystem.instance.equipItem(item);
        // }
        Debug.Log("Here");
        if (Inventory.instance != null)
        {
            Debug.Log("Ok");
            Inventory.instance.addItem(item);
        }
        Destroy(gameObject);
    }
}
