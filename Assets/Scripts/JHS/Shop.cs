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
        //goldText.text =  �÷��̾��� ���
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
        //�÷��̾��� ���� ����ؼ� ó��
        //����� �������� ������ ������ ��� ����
        //�ɰ��

        //�ȵɰ��
        itemCost = 0; 
        waringPanel.SetActive(true);
        purchasePanel.SetActive(false);
    }
}
