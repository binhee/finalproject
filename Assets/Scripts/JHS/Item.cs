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
            Inventory.instance.ClassifyAndCreateItem(itemType,itemImage);// collision은 부딫힌놈 즉 플레이어의 정보
            Destroy(gameObject);
        }
    }
}
