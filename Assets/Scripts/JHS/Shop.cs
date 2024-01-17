using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject purchasePanel;
    public GameObject waringPanel;
    public Text goldText;
    int itemCost;
    void Update()
    {
        //goldText.text =  플레이어의 골드
    }
    public void ExitPanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void PurchaseNotice(int cost)
    {
        itemCost= cost;
        purchasePanel.SetActive(true);
    }
    public void Purchase()
    {
        //플레이어의 골드와 계산해서 처리
        //현재는 조건으로 가져올 변수가 없어서 놔둠
        //될경우

        //안될경우
        itemCost = 0; 
        waringPanel.SetActive(true);
        purchasePanel.SetActive(false);
    }
}
