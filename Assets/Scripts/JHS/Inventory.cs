using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public GameObject inventoryPanel;
    public List<Slot> itemSlotList = new List<Slot>();
    public bool potionOwn;

    public int equipWeaponCount;
    public int equipArmorCount;
    public int playerGold;

    public Text[] infoTexts;

    private void Awake()
    {
            instance = this; 
    }
    private void Update()
    {
        OnOffInventoryPanel();
        
    }
    private void OnOffInventoryPanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitInventoryPanel();
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(true);
        }
    }
    public void ExitInventoryPanel()
    {
        inventoryPanel.SetActive(false);
    }
    public void PotionDetect()
    {
        for (int i = 0; i < itemSlotList.Count; i++)
        {
            if (itemSlotList[i].transform.childCount == 1)
            {
                if (itemSlotList[i].transform.GetChild(0).GetComponent<DraggableUI>().itemImageType == ItemType.HpPotion)
                {
                    potionOwn=true;
                    break;
                }
            }
            else
            {
                potionOwn = false;
            }
        }
    }

    public void ClassifyAndCreateItem(ItemType itemtype, GameObject invenItem)
    {
        PotionDetect();
        switch (itemtype)
        {
            case ItemType.HpPotion:
                for (int i = 0; i < itemSlotList.Count; i++)
                {
                    Transform slotTransform = itemSlotList[i].transform;
                    if (slotTransform.childCount == 0 && potionOwn == false)
                    {
                        Instantiate(invenItem, slotTransform).GetComponent<DraggableUI>().itemImageType = itemtype;
                        break;
                    }
                    else if (slotTransform.childCount == 1)
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
                for (int i = 0; i < itemSlotList.Count; i++)
                {
                    Transform slotTransform = itemSlotList[i].transform;
                    if (slotTransform.childCount == 0)
                    {
                        Instantiate(invenItem, slotTransform).GetComponent<DraggableUI>().itemImageType = itemtype;
                        break;
                    }
                }
                break;
            case ItemType.Weapon:
                for (int i = 0; i < itemSlotList.Count; i++)
                {
                    Transform slotTransform = itemSlotList[i].transform;
                    if (itemSlotList[i].transform.childCount == 0)
                    {
                        Instantiate(invenItem, slotTransform).GetComponent<DraggableUI>().itemImageType = itemtype;
                        break;
                    }
                }
                break;
            case ItemType.JumpPotion:

                break;
        }
    }
}
