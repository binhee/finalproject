using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public void InventoryLoad()     // 인벤토리 로드 함수
    {
        SceneManager.LoadScene("JHS_Item");     // "" 인벤토리 Scene 추가
    }

    public void StoreLoad()     // 상점 로드 함수
    {
        SceneManager.LoadScene("JHS_Item");     // "" 상점 Scene 추가
    }
}
