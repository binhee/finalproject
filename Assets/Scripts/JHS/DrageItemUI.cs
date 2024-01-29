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
    private Item itemComponent;

    public ItemType itemImageType;
    public int itemIDNUM;
    public GameObject descriptionPanel;
    public GameObject equipUI;
    public Text descriptionTxt;
    public Text potionCountTxt;
    public int itemCount = 1;
    public ItemSO itemSO;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        itemComponent = gameObject.GetComponent<Item>();
    }

    public void EquipItem()
    {
        if (transform.parent.GetComponent<Slot>().slotType != SlotType.AllSlot)
        {
            switch (itemComponent.itemType)
            {
                case ItemType.Weapon:
                    EquipWithType(0, descriptionTxt.text, ref Inventory.instance.equipWeaponCount);
                    gameObject.GetComponent<WeaponAction>().Use(itemSO);
                    break;
                case ItemType.Armor:
                    EquipWithType(1, descriptionTxt.text, ref Inventory.instance.equipArmorCount);
                    // 방어구 장착 할때의 동작
                    break;
                case ItemType.Helmet:
                    EquipWithType(2, descriptionTxt.text, ref Inventory.instance.equipHelmetCount);
                    // 헬멧 장착 할때의 동작
                    break;
                case ItemType.Boots:
                    EquipWithType(3, descriptionTxt.text, ref Inventory.instance.equipBootsCount);
                    // 부츠 장착 할때의 동작
                    break;
            }
        }
        else
        {
            switch (itemComponent.itemType)
            {
                case ItemType.Weapon:
                    UnequipWithType(0, ref Inventory.instance.equipWeaponCount);
                    gameObject.GetComponent<WeaponAction>().Delete();
                    break;
                case ItemType.Armor:
                    UnequipWithType(1, ref Inventory.instance.equipArmorCount);
                    // 방어구 해제 할때의 동작
                    break;
                case ItemType.Helmet:
                    UnequipWithType(2, ref Inventory.instance.equipHelmetCount);
                    // 헬멧 해제 할때의 동작
                    break;
                case ItemType.Boots:
                    UnequipWithType(3, ref Inventory.instance.equipBootsCount);
                    // 부츠 해제 할때의 동작
                    break;
            }
        }
    }

    private void EquipWithType(int index, string description, ref int equipCount)
    {
        equipUI.SetActive(true);
        equipCount++;
        Inventory.instance.infoTexts[index].text = description;
    }

    private void UnequipWithType(int index, ref int equipCount)
    {
        equipUI.SetActive(false);
        equipCount--;
        Inventory.instance.infoTexts[index].text = " ";
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


