using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject OptionPanel;
    public GameObject StagePanel;

    SoundManager soundManager;      // SoundManager ��ũ��Ʈ�� �׼���.

    private void Awake()
    {
        //�±װ� Sound�� SoundManager�� ����.
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }
    //public void InventoryLoad()     // �κ��丮 �ε� �Լ�
    //{
    //    soundManager.PlatSFX(soundManager.BTNSound);    // BTNSound ���
    //    GameObject go = Resources.Load<GameObject>("YSJ/Inventory");
    //    Instantiate(go);
    //    Debug.Log("1");
    //}

    //public void StoreLoad()     // ���� �ε� �Լ�
    //{
    //    soundManager.PlatSFX(soundManager.BTNSound);    // BTNSound ���
    //    GameObject go = Resources.Load<GameObject>("YSJ/Store");
    //    Instantiate(go);
    //    Debug.Log("2");
    //}

    public void SetStagePanel()
    {
        soundManager.PlatSFX(soundManager.BTNSound);    // BTNSound ���
        bool IsSetOptionPanel = StagePanel.activeSelf;
        StagePanel.SetActive(!IsSetOptionPanel);
    }
    public void SetOptionPanel() //�ɼ�â ���� ����
    {
        soundManager.PlatSFX(soundManager.BTNSound);    // BTNSound ���
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
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void MainSceneLoad()    // ����ȭ�� ����
    {
        SceneManager.LoadScene("Main");    // "" �������� �� ����
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void Stage1Load()    // ��������1 ����
    {
        SceneManager.LoadScene("JBH_Stage");    // "" �������� �� ����
    }

    public void Stage2Load()    // ��������2 ����
    {
        PlayerManager.instance.startPoint = new Vector2(5.5f, -1.4f);
        SceneManager.LoadScene("YSJ_TestStage");    // "" �������� �� ����
    }

    public void Stage3Load()    // ��������3 ����
    {
        PlayerManager.instance.startPoint = new Vector2(-16.0f, -8.0f);
        SceneManager.LoadScene("JDH_Boss2");    // "" �������� �� ����
    }

    public void TestStage2Load()    // ��������2 ����
    {
        PlayerManager.instance.startPoint = new Vector2(5.5f, -1.4f);
        SceneManager.LoadScene("JHS_Item_Stage");    // "" �������� �� ����
    }
}


