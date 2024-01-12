using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType { HpPotion, Weapon, Armor, JumpPotion }
public class Item : MonoBehaviour
{
    [Header("ItemInformation")]
    public ItemType type;
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
            ClassifyItem(type , collision);// collision은 부딫힌놈 즉 플레이어의 정보
            Destroy(gameObject);
        }
    }
    private void ClassifyItem(ItemType itemtype, Collision2D collision)
    {
        switch (itemtype)
        {
            case ItemType.HpPotion: // 플레이어의 회복할때

                break;
            case ItemType.Armor:
                for (int i = 0; i < Inventory.instance.itemSlotList.Count; i++)
                {
                    if (Inventory.instance.itemSlotList[i].transform.childCount == 0)
                    {
                        Instantiate(itemImage, Inventory.instance.itemSlotList[i].transform).GetComponent<DraggableUI>();
                        break;
                    }
                }
                break;
            case ItemType.Weapon:
                for (int i = 0; i < Inventory.instance.itemSlotList.Count; i++)
                {
                    if (Inventory.instance.itemSlotList[i].transform.childCount == 0)
                    {
                        Instantiate(itemImage, Inventory.instance.itemSlotList[i].transform).GetComponent<DraggableUI>();
                        break;
                    }
                }
                break;
            case ItemType.JumpPotion:

                break;
        }
    }
}
