using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject OptionPanel;
    public GameObject StagePanel;
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

    public void SetStagePanel()
    {
        bool IsSetOptionPanel = StagePanel.activeSelf;
        StagePanel.SetActive(!IsSetOptionPanel);
    }
    public void SetOptionPanel() //�ɼ�â ���� ����
    {
        bool IsSetOptionPanel = OptionPanel.activeSelf;
        OptionPanel.SetActive(!IsSetOptionPanel);
        if (!IsSetOptionPanel)
        {
            // �ǳ��� ��Ÿ�� �� �Ͻ�����
            Time.timeScale = 0f;
        }
        else
        {
            // �ǳ��� ����� �� �Ͻ����� ����
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = 0.02f*Time.timeScale;
    }

    public void MainSceneLoad()    // ����ȭ�� ����
    {
        SceneManager.LoadScene("YSJ_UI");    // "" �������� �� ����
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


