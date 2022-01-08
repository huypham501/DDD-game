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
        if (Inventory.instance != null)
        {
            Inventory.instance.addItem(item);
        }
        Destroy(gameObject);
    }
}
