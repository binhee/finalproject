using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject OptionPanel;
    public GameObject StagePanel;

    SoundManager soundManager;      // SoundManager 스크립트에 액세스.

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
        soundManager.PlatSFX(soundManager.BTNSound);    // BTNSound 재생
        bool IsSetOptionPanel = StagePanel.activeSelf;
        StagePanel.SetActive(!IsSetOptionPanel);
    }
    public void SetOptionPanel() //옵션창 생성 삭제
    {
        soundManager.PlatSFX(soundManager.BTNSound);    // BTNSound 재생
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

    public void MainSceneLoad()    // 메인화면 입장
    {
        SceneManager.LoadScene("Main");    // "" 스테이지 씬 삽입
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void Stage1Load()    // 스테이지1 입장
    {
        SceneManager.LoadScene("JBH_Stage");    // "" 스테이지 씬 삽입
    }

    public void Stage2Load()    // 스테이지2 입장
    {
        PlayerManager.instance.startPoint = new Vector2(5.5f, -1.4f);
        SceneManager.LoadScene("YSJ_TestStage");    // "" 스테이지 씬 삽입
    }

    public void Stage3Load()    // 스테이지3 입장
    {
        PlayerManager.instance.startPoint = new Vector2(-16.0f, -8.0f);
        SceneManager.LoadScene("JDH_Boss2");    // "" 스테이지 씬 삽입
    }

    public void TestStage2Load()    // 스테이지2 입장
    {
        PlayerManager.instance.startPoint = new Vector2(5.5f, -1.4f);
        SceneManager.LoadScene("JHS_Item_Stage");    // "" 스테이지 씬 삽입
    }
}


