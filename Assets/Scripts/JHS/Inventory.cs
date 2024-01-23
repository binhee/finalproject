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
}
