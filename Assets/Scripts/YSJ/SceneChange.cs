using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void InventoryLoad()     // �κ��丮 �ε� �Լ�
    {
        GameObject go = Resources.Load<GameObject>("YSJ/Inventory");
        Instantiate(go);
    }

    public void StoreLoad()     // ���� �ε� �Լ�
    {
        GameObject go = Resources.Load<GameObject>("YSJ/Store");
        Instantiate(go);
    }

    public void Stage1Load()    // ��������1 ����
    {
        SceneManager.LoadScene("JBH_Stage");    // "" �������� �� ����
    }

    public void Stage2Load()    // ��������2 ����
    {
        SceneManager.LoadScene("JBH_Stage");    // "" �������� �� ����
    }

    public void Stage3Load()    // ��������3 ����
    {
        SceneManager.LoadScene("JBH_Stage");    // "" �������� �� ����
    }
}


