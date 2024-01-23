using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType { HpPotion, Weapon, Helmet, Armor, Boots, JumpPotion }
public class Item : MonoBehaviour
{
    [Header("ItemInformation")]
    public ItemType itemType;
    public int itemPotionRecoveryAmount;

    public GameObject itemImage;
    private void Awake()
    {

    }
    void Start()
    {

    }
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ClassifyItem(itemType, collision);// collision은 부딫힌놈 즉 플레이어의 정보
            Destroy(gameObject);
        }
    }
    private void ClassifyItem(ItemType itemtype, Collision2D collision)
    {
        Inventory.instance.PotionDetect();
        switch (itemtype)
        {
            case ItemType.HpPotion:
                for (int i = 0; i < Inventory.instance.itemSlotList.Count; i++)
                {
                    Transform slotTransform = Inventory.instance.itemSlotList[i].transform;
                    if (slotTransform.childCount == 0 && Inventory.instance.potionOwn == false)
                    {
                        Instantiate(itemImage, slotTransform).GetComponent<DraggableUI>().itemImageType = itemtype;
                        break;
                    }
                    else if(slotTransform.childCount == 1)
                    {
                        if (slotTransform.GetChild(0).GetComponent<DraggableUI>().itemImageType == itemtype)
                        {
                            slotTransform.GetChild(0).GetComponent<DraggableUI>().itemCount++;
                            slotTransform.GetChild(0).GetComponent<DraggableUI>().UpdateText();
                            break;
                        }
                    }
                }
                break;
            case ItemType.Armor:
                for (int i = 0; i < Inventory.instance.itemSlotList.Count; i++)
                {
                    Transform slotTransform = Inventory.instance.itemSlotList[i].transform;
                    if (slotTransform.childCount == 0)
                    {
                        Instantiate(itemImage, slotTransform).GetComponent<DraggableUI>().itemImageType = itemtype;
                        break;
                    }
                }
                break;
            case ItemType.Weapon:
                for (int i = 0; i < Inventory.instance.itemSlotList.Count; i++)
                {
                    Transform slotTransform = Inventory.instance.itemSlotList[i].transform;
                    if (Inventory.instance.itemSlotList[i].transform.childCount == 0)
                    {
                        Instantiate(itemImage, slotTransform).GetComponent<DraggableUI>().itemImageType = itemtype;
                        break;
                    }
                }
                break;
            case ItemType.JumpPotion:

                break;
        }
    }
}
