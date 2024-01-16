using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Transform canvas;             
    private Transform previousParent;     
    private RectTransform rect;          
    private CanvasGroup canvasGroup;

    public GameObject descriptionPanel;
    public GameObject equipUI;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
    }
    public void EquipItem()
    {
        if (transform.parent.GetComponent<Slot>().slotType != SlotType.AllSlot)
        {
            if (gameObject.GetComponent<Item>().itemType == ItemType.Weapon)
            {
                    equipUI.SetActive(true);
                    Inventory.instance.equipWeaponCount++;
                    //무기 장착 할때

            }
            else if (gameObject.GetComponent<Item>().itemType == ItemType.Armor)
            {
                    equipUI.SetActive(true);
                    Inventory.instance.equipArmorCount++;
                    //방어구 장착 할때

            }
        }
        else
        {
            if (gameObject.GetComponent<Item>().itemType == ItemType.Weapon)
            {
                equipUI.SetActive(false);
                Inventory.instance.equipWeaponCount--;
                //무기 장착해제 할때
            }
            if (gameObject.GetComponent<Item>().itemType == ItemType.Armor)
            {
                equipUI.SetActive(false);
                Inventory.instance.equipArmorCount--;
                //방어구 장착해제 할때
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        previousParent = transform.parent;

        transform.SetParent(canvas);        
        transform.SetAsLastSibling();    

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == canvas)
        {
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
        }
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionPanel.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionPanel.SetActive(false);
    }

}

