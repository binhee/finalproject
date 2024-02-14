using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageMenu : MonoBehaviour
{
    public Button[] buttons;    // 스테이지 입장 버튼

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);     // 완료된 레벨 수 저장.
        for (int i = 0; i < buttons.Length; i++)    // 버튼 수 만큼 버튼을 false처리.
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)     // unlockLevel 만큼 버튼을 true 처리.
        {
            buttons[i].interactable = true;
        }

    }

    
}
