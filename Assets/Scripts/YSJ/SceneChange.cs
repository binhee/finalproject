using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject OptionPanel;
    public GameObject StagePanel;
    public void InventoryLoad()     // 인벤토리 로드 함수
    {
        GameObject go = Resources.Load<GameObject>("YSJ/Inventory");
        Instantiate(go);
    }

    public void StoreLoad()     // 상점 로드 함수
    {
        GameObject go = Resources.Load<GameObject>("YSJ/Store");
        Instantiate(go);
    }

    public void SetStagePanel()
    {
        bool IsSetOptionPanel = StagePanel.activeSelf;
        StagePanel.SetActive(!IsSetOptionPanel);
    }
    public void SetOptionPanel() //옵션창 생성 삭제
    {
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
        Time.fixedDeltaTime = 0.02f*Time.timeScale;
    }

    public void MainSceneLoad()    // 메인화면 입장
    {
        SceneManager.LoadScene("YSJ_UI");    // "" 스테이지 씬 삽입
    }

    public void Stage1Load()    // 스테이지1 입장
    {
        SceneManager.LoadScene("JBH_Stage");    // "" 스테이지 씬 삽입
    }

    public void Stage2Load()    // 스테이지2 입장
    {
        SceneManager.LoadScene("JBH_Stage");    // "" 스테이지 씬 삽입
    }

    public void Stage3Load()    // 스테이지3 입장
    {
        SceneManager.LoadScene("JBH_Stage");    // "" 스테이지 씬 삽입
    }
}


