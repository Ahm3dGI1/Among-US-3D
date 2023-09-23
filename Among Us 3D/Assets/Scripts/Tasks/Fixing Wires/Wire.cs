using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wire : MonoBehaviour
{
    public RectTransform wireEnd;
    public float wireLength = 0.0f;
    [SerializeField] private Canvas canvas;

    Vector2 startPoint;
    Vector2 startPosition;

    private void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out position);

        UpdateWire(position);
    }

    public void EndDragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        UpdateWire(startPosition);
    }

    void UpdateWire(Vector2 position)
    {
        transform.position = canvas.transform.TransformPoint(position);

        //update direction
        Vector2 direction = (Vector2)transform.position - startPoint;
        transform.right = direction * transform.lossyScale.x;

        //update length
        float length = Vector2.Distance(startPoint, transform.position);
        wireEnd.sizeDelta = new Vector2(length, wireEnd.sizeDelta.y);
    }
}