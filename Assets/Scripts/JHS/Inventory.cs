using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public GameObject effectController;

    public GameObject inventoryPanel;
    public List<Slot> itemSlotList = new List<Slot>();
    public List<Slot> potionEquipSlots = new List<Slot>();
    public bool potionOwn;

    public int equipWeaponCount;
    public int equipArmorCount;
    public int equipHelmetCount;
    public int equipBootsCount;


    public Text[] infoTexts;
    public GameObject[] itemEffect;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
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
    public void PotionDetect(ItemType type)
    {
        for (int i = 0; i < itemSlotList.Count; i++) // ��ü ���� �˻�
        {
            if (itemSlotList[i].transform.childCount == 1)// �ڽ��� ���� �ҽ�? ( ������ �ڽ����� �������� �Ҵ��� )
            {
                // ������ �ڽ��� ������ Ÿ�� ����
                //������ Ÿ���� ���� ����(Weapon, Armor, Boots, Helmet)�� �ƴ� ���
                //potionOwn�� Ŵ ( ���� ���θ� Ŵ )

                var itemtype = itemSlotList[i].transform.GetChild(0).GetComponent<DraggableUI>().itemImageType;
                if (itemtype == type && type != ItemType.Weapon && type != ItemType.Armor && type != ItemType.Boots && type != ItemType.Helmet)
                {
                    potionOwn = true;
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
        PotionDetect(itemtype);// ���� ���Կ� ������ �ִ��� �Ǵ��� bool�� ����

        switch (itemtype)
        {
            case ItemType.Helmet:
            case ItemType.Boots:
            case ItemType.Armor:
            case ItemType.Weapon:
            case ItemType.Other:
                CreateEquipment(itemtype, invenItem);    //�����̸� ���⼭ ����
                break;

            case ItemType.HpPotion:
            case ItemType.JumpPotion:
            case ItemType.SpeedPotion:
            case ItemType.EnchantPotion:
                CreatePotion(itemtype, invenItem);    //���ǵ��̸� ���⼭ ����
                break;
        }
    }
    public void CreateEquipment(ItemType itemtype, GameObject invenItem)
    {
        for (int i = 0; i < itemSlotList.Count; i++) // ��ü ���� �˻�
        {
            Transform slotTransform = itemSlotList[i].transform; // �̹��� �˻��ϴ� i��° ����
            if (itemSlotList[i].transform.childCount == 0) // �ؿ� �ڽ��� ���ο� ���� ������ ���縦 �Ǵ� (���� �� �ڽ����� �������� �Ҵ���)
            {
                Instantiate(invenItem, slotTransform).GetComponent<DraggableUI>().itemImageType = itemtype;
                break;
            }
        }
    }
    public void CreatePotion(ItemType itemtype, GameObject invenItem)
    {
        for (int i = 0; i < itemSlotList.Count; i++) // ��ü ���� �˻�
        {
            Transform slotTransform = itemSlotList[i].transform; // �̹��� �˻��ϴ� i��° ����

            if (slotTransform.childCount == 0 && potionOwn == false) // ���� �� �ڽ�(�������� ������ �ڽ����� �Ҵ��)�� ����  PotionDetect���� �ɸ���������
            {
                Instantiate(invenItem, slotTransform).GetComponent<DraggableUI>().itemImageType = itemtype; // ����
                break;
            }
            else if (slotTransform.childCount == 1 && potionOwn == true)// ���� �� �ڽ�(�������� ������ �ڽ����� �Ҵ��)�� �ְ� PotionDetect���� �ɸ���
            {
                DraggableUI existItem = slotTransform.GetChild(0).GetComponent<DraggableUI>(); // ������ �ڽ��� ����(���� �� �������� ����)

                if (existItem.itemImageType == itemtype)// ���� �� �������� �˻��� ���� �����۰� ������?
                {
                    potionOwn = false;
                    existItem.itemCount++; // ������ �ø���.
                    existItem.UpdateText();
                    break;
                }
            }
        }
    }
}
