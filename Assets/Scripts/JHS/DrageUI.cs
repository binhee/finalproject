using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrageUI : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public RectTransform window; 
    private Vector2 downPosition;
    public Vector3 a;

    private void Update()
    {
        a = window.position;
        if (a.x < 560)
        {
            a.x = 560;
        }
        if (a.y < 228)
        {
            a.y = 228;
        }
        if (a.x > 1360)
        {
            a.x = 1360;
        }
        if (a.y > 852)
        {
            a.y = 852;
        }
        window.position = a;
    }
    public void OnPointerDown(PointerEventData data)
    {
        downPosition = data.position;
    }

    public void OnDrag(PointerEventData data)
    {
        a = window.position;
        Vector2 offset = data.position - downPosition;
        downPosition = data.position;

        window.anchoredPosition += offset;
    }
}
