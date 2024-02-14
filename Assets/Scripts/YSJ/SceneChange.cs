using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject OptionPanel;
    public GameObject StagePanel;
    public GameObject TileOptionclosePanel;
    public GameObject panel;
    SoundManager soundManager;      // SoundManager ��ũ��Ʈ�� �׼���.
    VolumeSettings volumeSettings;      // VolumeSettings ��ũ��Ʈ�� �׼���.
    PlayerRespawn playerRespawn;


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
        soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound ���
        bool IsSetStagePanel = StagePanel.activeSelf;
        StagePanel.SetActive(!IsSetStagePanel);
    }
    public void SetOptionPanel() //�ɼ�â ���� ����
    {
        soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound ���
        
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

    //public void SetTitleOptionPanel()
    //{
    //    if (SceneManager.GetActiveScene().buildIndex==0)
    //    {
    //        TileOptionclosePanel.SetActive(true);
    //    }
    //    else
    //    {
    //        TileOptionclosePanel.SetActive(false);
    //    }
    //}
    

    public void MainSceneLoad()    // ����ȭ�� ����
    {
        soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound ���
        SceneManager.LoadScene("Main");    // "" �������� �� ����
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;        
    }
    public void GoMainBtn()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SetOptionPanel();
        }
        else
        {
            soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound ���
            bool IsSetOptionPanel = OptionPanel.activeSelf;
            OptionPanel.SetActive(!IsSetOptionPanel);
            SceneManager.LoadScene("Main");    // "" �������� �� ����
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }
    public void InvenPanel()
    {
        soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound ���
        Inventory.instance.inventoryPanel.SetActive(true);
    }

    public void OpenStage(int levelID)    // �������� ���� ��ư
    {
        soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound ���
        SceneManager.LoadScene(levelID+1);
        PlayerManager.instance.startPoint = new Vector2(27, -4);
    }

    //public void Stage1Load()    // ��������1 ����
    //{
    //    soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound ���
    //    PlayerManager.instance.startPoint = new Vector2(27, -4);
    //    SceneManager.LoadScene("JBH_Stage");    // "" �������� �� ����
    //}

    //public void Stage2Load()    // ��������2 ����
    //{
    //    soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound ���
    //    PlayerManager.instance.startPoint = new Vector2(27, -4);
    //    SceneManager.LoadScene("JBH_Stage2");    // "" �������� �� ����
    //}

    //public void Stage3Load()    // ��������3 ����
    //{
    //    PlayerManager.instance.startPoint = new Vector2(27, -4);
    //    SceneManager.LoadScene("JDH_Boss2");    // "" �������� �� ����
    //}

    //public void TestStage2Load()    // ��������2 ����
    //{
    //    PlayerManager.instance.startPoint = new Vector2(27, -4);
    //    SceneManager.LoadScene("JHS_Item_Stage");    // "" �������� �� ����
    //}
}


