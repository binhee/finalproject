using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public GameObject effectController;

    public GameObject inventoryPanel;
    public List<Slot> itemSlotList = new List<Slot>();
    public List<Slot> potionEquipSlots = new List<Slot>();
    public bool potionOwn;
    public bool isDrag;

    public int equipWeaponCount;
    public int equipArmorCount;
    public int equipHelmetCount;
    public int equipBootsCount;


    public TextMeshProUGUI[] infoTexts;
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
        if (SceneManager.GetActiveScene().name != "Title")
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


    public void PotionUseAction(ItemSO itemNum)
    {
        switch (itemNum.itemIDNum)
        {
            case 0://hp
                StartCoroutine(Inventory.instance.Shield(itemNum));
                break;
            case 1://jump
                StartCoroutine(Inventory.instance.Jump(itemNum));
                break;
            case 2://speed
                StartCoroutine(Inventory.instance.Speed(itemNum));
                break;
            case 3://enchant
                StartCoroutine(Inventory.instance.Enchant(itemNum));
                break;
        }
    }
    public IEnumerator Shield(ItemSO itemSO)
    {
        GameObject player = PlayerManager.instance.FindPlayer();

        Debug.Log(" ���� ���� ");
        GameObject effect = Instantiate(Inventory.instance.itemEffect[0], Inventory.instance.effectController.transform);
        player.tag = "NonPlayer";
        player.layer = 12;
        yield return new WaitForSeconds(itemSO.shieldTime);
        Destroy(effect);
        Debug.Log(" ȿ�� ��");
        player.tag = "Player";
        player.layer = 8;
    }
   public IEnumerator Jump(ItemSO itemSO)
    {
        PlayerInputController playerJump = PlayerManager.instance.FindPlayer().GetComponent<PlayerInputController>();

        Debug.Log(" ���� ���� ");
        playerJump.jumpForce += itemSO.jumpPower;
        yield return new WaitForSeconds(itemSO.jumpTime);
        Debug.Log(" ȿ�� ��");
        playerJump.jumpForce -= itemSO.jumpPower;
    }
   public IEnumerator Speed(ItemSO itemSO)
    {
        CharacterStatsHandler playerHandler = PlayerManager.instance.FindPlayer().GetComponent<CharacterStatsHandler>();
        Debug.Log(" �ӵ� ���� ");
        playerHandler.CurrentStats.speed += itemSO.speedPower;
        yield return new WaitForSeconds(itemSO.speedTime);
        Debug.Log(" ȿ�� �� ");
        playerHandler.CurrentStats.speed -= itemSO.speedPower;
    }
   public IEnumerator Enchant(ItemSO itemSO)
    {
        Debug.Log(" ��ȭ ���� ");
        PlayerManager.instance.playerDamage += itemSO.enchantPower;
        yield return new WaitForSeconds(itemSO.enchantTime);
        Debug.Log(" ȿ�� �� ");
        PlayerManager.instance.playerDamage -= itemSO.enchantPower;
    }
}
