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
    SoundManager soundManager;      // SoundManager 스크립트에 액세스.
    VolumeSettings volumeSettings;      // VolumeSettings 스크립트에 액세스.
    PlayerRespawn playerRespawn;


    private void Awake()
    {
        //태그가 Sound인 SoundManager에 접근.
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }
    //public void InventoryLoad()     // 인벤토리 로드 함수
    //{
    //    soundManager.PlatSFX(soundManager.BTNSound);    // BTNSound 재생
    //    GameObject go = Resources.Load<GameObject>("YSJ/Inventory");
    //    Instantiate(go);
    //    Debug.Log("1");
    //}

    //public void StoreLoad()     // 상점 로드 함수
    //{
    //    soundManager.PlatSFX(soundManager.BTNSound);    // BTNSound 재생
    //    GameObject go = Resources.Load<GameObject>("YSJ/Store");
    //    Instantiate(go);
    //    Debug.Log("2");
    //}

    public void SetStagePanel()
    {
        soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound 재생
        bool IsSetStagePanel = StagePanel.activeSelf;
        StagePanel.SetActive(!IsSetStagePanel);
    }
    public void SetOptionPanel() //옵션창 생성 삭제
    {
        soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound 재생
        
        bool IsSetOptionPanel = OptionPanel.activeSelf;
        OptionPanel.SetActive(!IsSetOptionPanel);
        if (!IsSetOptionPanel)
        {
            // 판넬이 나타날 때 일시정지
            Time.timeScale = 0f;
        }
        else
        {
            // 판넬이 사라질 때 일시정지 해제
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
    

    public void MainSceneLoad()    // 메인화면 입장
    {
        soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound 재생
        SceneManager.LoadScene("Main");    // "" 스테이지 씬 삽입
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
            soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound 재생
            bool IsSetOptionPanel = OptionPanel.activeSelf;
            OptionPanel.SetActive(!IsSetOptionPanel);
            SceneManager.LoadScene("Main");    // "" 스테이지 씬 삽입
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }
    public void InvenPanel()
    {
        soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound 재생
        Inventory.instance.inventoryPanel.SetActive(true);
    }

    public void OpenStage(int levelID)    // 스테이지 입장 버튼
    {
        soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound 재생
        SceneManager.LoadScene(levelID+1);
        PlayerManager.instance.startPoint = new Vector2(27, -4);
    }

    //public void Stage1Load()    // 스테이지1 입장
    //{
    //    soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound 재생
    //    PlayerManager.instance.startPoint = new Vector2(27, -4);
    //    SceneManager.LoadScene("JBH_Stage");    // "" 스테이지 씬 삽입
    //}

    //public void Stage2Load()    // 스테이지2 입장
    //{
    //    soundManager.PlaySFX(soundManager.BTNSound);    // BTNSound 재생
    //    PlayerManager.instance.startPoint = new Vector2(27, -4);
    //    SceneManager.LoadScene("JBH_Stage2");    // "" 스테이지 씬 삽입
    //}

    //public void Stage3Load()    // 스테이지3 입장
    //{
    //    PlayerManager.instance.startPoint = new Vector2(27, -4);
    //    SceneManager.LoadScene("JDH_Boss2");    // "" 스테이지 씬 삽입
    //}

    //public void TestStage2Load()    // 스테이지2 입장
    //{
    //    PlayerManager.instance.startPoint = new Vector2(27, -4);
    //    SceneManager.LoadScene("JHS_Item_Stage");    // "" 스테이지 씬 삽입
    //}
}


