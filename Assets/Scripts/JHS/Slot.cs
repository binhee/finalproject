using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum SlotType { PotionSlot, WeaponSlot, ArmorSlot, HelmetSlot, BootsSlot, ArtifactSlot, AllSlot, EnforceSlot, CombinationSlot }
public class Slot : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    [Header("ItemInformation")]
    public SlotType slotType;

    GameObject canvasInven;

    private Image image;
    private RectTransform rect;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.gray;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.GetComponent<DrageUI>() != null) // 인벤토리를 드래그할때 예외처리
        {
            return;
        }


        if (eventData.pointerDrag != null && gameObject.transform.childCount == 1)
        {
            DraggableUI existUI = transform.GetChild(0).GetComponent<DraggableUI>(); // 현재 밑에 자식으로 슬롯에 존재하는 아이템
            DraggableUI dragUI = eventData.pointerDrag.GetComponent<DraggableUI>(); // 현재 드래그 중인 아이템

            if (existUI.itemImageType == dragUI.itemImageType
                &&dragUI.itemImageType!=ItemType.Weapon && dragUI.itemImageType != ItemType.Helmet
                && dragUI.itemImageType != ItemType.Armor && dragUI.itemImageType != ItemType.Boots &&dragUI.itemImageType != ItemType.Other)
            {
                existUI.itemCount += dragUI.itemCount;
                existUI.UpdateText();
                Destroy(eventData.pointerDrag);
            }
        }
        if (eventData.pointerDrag != null && gameObject.transform.childCount==0 && CheckType(eventData))
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
            if (slotType == SlotType.EnforceSlot|| slotType == SlotType.CombinationSlot)
            {
                return;
            }
            else
            {
                eventData.pointerDrag.GetComponent<DraggableUI>().EquipItem();
            }
        }
    }
    bool CheckType(PointerEventData item)
    {
        
        Item checkItemType = item.pointerDrag.GetComponent<Item>();
        if (slotType == SlotType.AllSlot)
        {
            return true;
        }
        if(checkItemType.itemType == ItemType.Weapon&& slotType==SlotType.WeaponSlot)
        {
            return true;
        }
        if (checkItemType.itemType == ItemType.Helmet && slotType == SlotType.HelmetSlot)
        {
            return true;
        }
        if (checkItemType.itemType == ItemType.Armor && slotType == SlotType.ArmorSlot)
        {
            return true;
        }
        if (checkItemType.itemType == ItemType.Boots && slotType == SlotType.BootsSlot)
        {
            return true;
        }
        if (checkItemType.itemType == ItemType.Other && slotType == SlotType.CombinationSlot)
        {
            return true;
        }
        if (checkItemType.itemType == ItemType.Weapon|| checkItemType.itemType == ItemType.Boots || checkItemType.itemType == ItemType.Armor || checkItemType.itemType == ItemType.Helmet)
        {
            if (slotType == SlotType.EnforceSlot)
            {
                return true;
            }
            if (slotType == SlotType.CombinationSlot)
            {
                return true;
            }
        }
        if (checkItemType.itemType == ItemType.HpPotion || checkItemType.itemType == ItemType.JumpPotion ||
            checkItemType.itemType == ItemType.SpeedPotion || checkItemType.itemType == ItemType.EnchantPotion)
        {
            if(slotType == SlotType.PotionSlot)
            {
                return true;
            }
        }
        return false;
    }
}

