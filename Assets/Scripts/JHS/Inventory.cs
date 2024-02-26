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
        for (int i = 0; i < itemSlotList.Count; i++) // 전체 슬롯 검사
        {
            if (itemSlotList[i].transform.childCount == 1)// 자식이 존재 할시? ( 슬롯의 자식으로 아이템을 할당함 )
            {
                // 존재한 자식의 아이템 타입 저장
                //아이템 타입이 같고 장비류(Weapon, Armor, Boots, Helmet)이 아닐 경우
                //potionOwn을 킴 ( 포션 여부를 킴 )

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
        PotionDetect(itemtype);// 현재 슬롯에 포션이 있는지 판단해 bool로 연계

        switch (itemtype)
        {
            case ItemType.Helmet:
            case ItemType.Boots:
            case ItemType.Armor:
            case ItemType.Weapon:
            case ItemType.Other:
                CreateEquipment(itemtype, invenItem);    //장비들이면 여기서 생성
                break;

            case ItemType.HpPotion:
            case ItemType.JumpPotion:
            case ItemType.SpeedPotion:
            case ItemType.EnchantPotion:
                CreatePotion(itemtype, invenItem);    //포션들이면 여기서 생성
                break;
        }
    }
    public void CreateEquipment(ItemType itemtype, GameObject invenItem)
    {
        for (int i = 0; i < itemSlotList.Count; i++) // 전체 슬롯 검사
        {
            Transform slotTransform = itemSlotList[i].transform; // 이번에 검사하는 i번째 슬롯
            if (itemSlotList[i].transform.childCount == 0) // 밑에 자식의 여부에 따라 아이템 존재를 판단 (슬롯 및 자식으로 아이템을 할당함)
            {
                Instantiate(invenItem, slotTransform).GetComponent<DraggableUI>().itemImageType = itemtype;
                break;
            }
        }
    }
    public void CreatePotion(ItemType itemtype, GameObject invenItem)
    {
        for (int i = 0; i < itemSlotList.Count; i++) // 전체 슬롯 검사
        {
            Transform slotTransform = itemSlotList[i].transform; // 이번에 검사하는 i번째 슬롯

            if (slotTransform.childCount == 0 && potionOwn == false) // 슬롯 밑 자식(아이템이 있으면 자식으로 할당됨)이 없고  PotionDetect에서 걸리지않으면
            {
                Instantiate(invenItem, slotTransform).GetComponent<DraggableUI>().itemImageType = itemtype; // 생성
                break;
            }
            else if (slotTransform.childCount == 1 && potionOwn == true)// 슬롯 및 자식(아이템이 있으면 자식으로 할당됨)이 있고 PotionDetect에서 걸리면
            {
                DraggableUI existItem = slotTransform.GetChild(0).GetComponent<DraggableUI>(); // 슬롯의 자식을 참조(슬롯 안 아이템을 참조)

                if (existItem.itemImageType == itemtype)// 슬롯 안 아이템을 검사해 먹은 아이템과 같으면?
                {
                    potionOwn = false;
                    existItem.itemCount++; // 갯수를 늘린다.
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

        Debug.Log(" 쉴드 포션 ");
        GameObject effect = Instantiate(Inventory.instance.itemEffect[0], Inventory.instance.effectController.transform);
        player.tag = "NonPlayer";
        player.layer = 12;
        yield return new WaitForSeconds(itemSO.shieldTime);
        Destroy(effect);
        Debug.Log(" 효과 끝");
        player.tag = "Player";
        player.layer = 8;
    }
   public IEnumerator Jump(ItemSO itemSO)
    {
        PlayerInputController playerJump = PlayerManager.instance.FindPlayer().GetComponent<PlayerInputController>();

        Debug.Log(" 점프 포션 ");
        playerJump.jumpForce += itemSO.jumpPower;
        yield return new WaitForSeconds(itemSO.jumpTime);
        Debug.Log(" 효과 끝");
        playerJump.jumpForce -= itemSO.jumpPower;
    }
   public IEnumerator Speed(ItemSO itemSO)
    {
        CharacterStatsHandler playerHandler = PlayerManager.instance.FindPlayer().GetComponent<CharacterStatsHandler>();
        Debug.Log(" 속도 포션 ");
        playerHandler.CurrentStats.speed += itemSO.speedPower;
        yield return new WaitForSeconds(itemSO.speedTime);
        Debug.Log(" 효과 끝 ");
        playerHandler.CurrentStats.speed -= itemSO.speedPower;
    }
   public IEnumerator Enchant(ItemSO itemSO)
    {
        Debug.Log(" 강화 포션 ");
        PlayerManager.instance.playerDamage += itemSO.enchantPower;
        yield return new WaitForSeconds(itemSO.enchantTime);
        Debug.Log(" 효과 끝 ");
        PlayerManager.instance.playerDamage -= itemSO.enchantPower;
    }
}
