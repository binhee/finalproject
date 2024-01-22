using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public enum SlotType { PotionSlot, WeaponSlot, ArmorSlot, HelmetSlot, BootsSlot, ArtifactSlot, AllSlot}
public class Slot : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    [Header("ItemInformation")]
    public SlotType slotType;

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
        if (eventData.pointerDrag != null && gameObject.transform.childCount == 1 && eventData.pointerDrag.GetComponent<DraggableUI>().itemImageType == ItemType.HpPotion)
        {
            if (transform.GetChild(0).GetComponent<DraggableUI>().itemImageType == ItemType.HpPotion)
            {
                transform.GetChild(0).GetComponent<DraggableUI>().itemCount += eventData.pointerDrag.GetComponent<DraggableUI>().itemCount;
                transform.GetChild(0).GetComponent<DraggableUI>().UpdateText();
                Destroy(eventData.pointerDrag);
            }
        }
        if (eventData.pointerDrag != null && gameObject.transform.childCount==0 && CheckType(eventData))
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<DraggableUI>().EquipItem();
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
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
        if (checkItemType.itemType == ItemType.HpPotion || checkItemType.itemType == ItemType.JumpPotion)
        {
            if(slotType == SlotType.PotionSlot)
            {
                return true;
            }
        }
        return false;
    }
}

