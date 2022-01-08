using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
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
        Debug.Log("OnPointerDown");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
        transform.SetParent(CanvasController.instance.canvas.transform);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / CanvasController.instance.getScaleFactor();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
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
        Debug.Log("HEREE");
    }
}
