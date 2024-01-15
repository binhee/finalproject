using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
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


