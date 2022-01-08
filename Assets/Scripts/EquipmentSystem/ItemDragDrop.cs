using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject parentInventoryItemCell;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 rootPositionVector2;
    private Transform rootParent;
    private bool isEquip = false;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (rectTransform != null)
        {
            rootPositionVector2 = rectTransform.anchoredPosition;
            rootParent = transform.parent;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
        transform.SetParent(CanvasController.instance.canvas.transform);
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / CanvasController.instance.getScaleFactor();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        if (!isEquip)
        {
            transform.SetParent(rootParent);
            rectTransform.anchoredPosition = rootPositionVector2;
        }
    }
    public void setEquip()
    {
        isEquip = true;
        Destroy(gameObject);
        Inventory.instance.removeItem(parentInventoryItemCell.GetComponent<InventoryItemCell>().getIndex());
    }
    public Item getItem()
    {
        return Inventory.instance.getItem(parentInventoryItemCell.GetComponent<InventoryItemCell>().getIndex());
    }
}