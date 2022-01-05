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
        // EquipmentSystem.instance.equipItem(item);
        if (EquipmentSystem.instance != null)
        {
            Debug.Log("System exists");
        }
        Destroy(gameObject);
    }
}
