using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static PotionControl;

public class Shop : MonoBehaviour
{
    public class ShopItemList
    {
        public GameObject shopItemImage;
        public int itemCost;
    }
    public List<ShopItemList> shopList;

    public GameObject purchasePanel;
    public GameObject waringPanel;
    public Text goldText;
    int itemIndexNum;
    void Update()
    {
        goldText.text = $"{Inventory.instance.playerGold}";
    }
    public void ExitPanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void PurchaseNotice(int indexNum)
    {
        itemIndexNum = indexNum;
        purchasePanel.SetActive(true);
    }
    public void Purchase()
    {
        //�ɰ��
        if (shopList[itemIndexNum].itemCost <= Inventory.instance.playerGold)
        {
            Inventory.instance.playerGold -= shopList[itemIndexNum].itemCost;
        }
        else if (shopList[itemIndexNum].itemCost > Inventory.instance.playerGold)//�ȵɰ��
        {
            waringPanel.SetActive(true);
        }
        purchasePanel.SetActive(false);
    }
}
