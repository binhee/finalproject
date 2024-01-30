using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrageUI : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public RectTransform window; 
    private Vector2 downPosition;

    public void OnPointerDown(PointerEventData data)
    {
        downPosition = data.position;
    }

    public void OnDrag(PointerEventData data)
    {
        Vector2 offset = data.position - downPosition;
        downPosition = data.position;

        window.anchoredPosition += offset;
    }
}
