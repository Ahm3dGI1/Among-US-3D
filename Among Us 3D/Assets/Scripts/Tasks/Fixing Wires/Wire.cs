using UnityEngine;
using UnityEngine.EventSystems;

public class Wire : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform wireEnd;
    [SerializeField] private Canvas canvas;

    private Vector2 startPoint;
    private Vector2 startPosition;
    private Vector2 offset;

    private void Start()
    {
        startPoint = transform.parent.position;
        offset = new Vector2(-173f, 80f);
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            eventData.position,
            canvas.worldCamera,
            out position);

        UpdateWirePosition(position);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, .2f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                UpdateWirePosition(collider.transform.position);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        startPosition = transform.position + (Vector3)wireEnd.anchoredPosition;
        UpdateWirePosition(startPosition - offset);
    }

    private void UpdateWirePosition(Vector2 position)
    {
        transform.position = canvas.transform.TransformPoint(position);

        Vector2 direction = (Vector2)wireEnd.position - startPoint;
        transform.right = direction * transform.lossyScale.x;

        float length = Vector2.Distance(startPosition, transform.position);
        wireEnd.sizeDelta = new Vector2(length, wireEnd.sizeDelta.y);
    }
}