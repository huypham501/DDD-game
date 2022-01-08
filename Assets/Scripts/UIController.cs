using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject UIInventoryObject;
    private bool isOpenUIInventory;
    private void Awake()
    {
        isOpenUIInventory = false;
        UIInventoryObject.SetActive(isOpenUIInventory);
    }
    private void Update()
    {
        #region Inventory controller
        if (Input.GetKeyDown(KeyCode.B))
        {
            isOpenUIInventory = !isOpenUIInventory;
            UIInventoryObject.SetActive(isOpenUIInventory);
        }
        #endregion
    }
}
