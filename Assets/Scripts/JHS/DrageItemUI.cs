using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Transform canvas;
    private Transform previousParent;
    private RectTransform rect;
    private CanvasGroup canvasGroup;

    public ItemType itemImageType;
    public GameObject descriptionPanel;
    public GameObject equipUI;
    public Text descriptionTxt;
    public Text potionCountTxt;
    public int itemCount = 1;
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
                Inventory.instance.infoTexts[0].text = descriptionTxt.text;
                //무기 장착 할때

            }
            else if (gameObject.GetComponent<Item>().itemType == ItemType.Armor)
            {
                equipUI.SetActive(true);
                Inventory.instance.equipArmorCount++;
                Inventory.instance.infoTexts[1].text = descriptionTxt.text;
                //방어구 장착 할때

            }
            else if (gameObject.GetComponent<Item>().itemType == ItemType.Helmet)
            {
                equipUI.SetActive(true);
                //Inventory.instance.equipArmorCount++;
                Inventory.instance.infoTexts[2].text = descriptionTxt.text;
                //방어구 장착 할때

            }
            else if (gameObject.GetComponent<Item>().itemType == ItemType.Boots)
            {
                equipUI.SetActive(true);
                //Inventory.instance.equipArmorCount++;
                Inventory.instance.infoTexts[3].text = descriptionTxt.text;
                //방어구 장착 할때

            }
        }
        else
        {
            if (gameObject.GetComponent<Item>().itemType == ItemType.Weapon)
            {
                equipUI.SetActive(false);
                Inventory.instance.equipWeaponCount--;
                Inventory.instance.infoTexts[0].text = " ";
                //무기 장착해제 할때
            }
            if (gameObject.GetComponent<Item>().itemType == ItemType.Armor)
            {
                equipUI.SetActive(false);
                Inventory.instance.equipArmorCount--;
                Inventory.instance.infoTexts[1].text = " ";
                //방어구 장착해제 할때
            }
            if (gameObject.GetComponent<Item>().itemType == ItemType.Helmet)
            {
                equipUI.SetActive(false);
                // Inventory.instance.equipArmorCount--;
                Inventory.instance.infoTexts[2].text = " ";
                //방어구 장착해제 할때
            }
            if (gameObject.GetComponent<Item>().itemType == ItemType.Boots)
            {
                equipUI.SetActive(false);
                //Inventory.instance.equipArmorCount--;
                Inventory.instance.infoTexts[3].text = " ";
                //방어구 장착해제 할때
            }
        }
    }
    public void UpdateText()
    {
        potionCountTxt.text = $"{itemCount}";
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

