using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageMenu : MonoBehaviour
{
    public Button[] buttons;    // �������� ���� ��ư

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);     // �Ϸ�� ���� �� ����.
        for (int i = 0; i < buttons.Length; i++)    // ��ư �� ��ŭ ��ư�� falseó��.
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)     // unlockLevel ��ŭ ��ư�� true ó��.
        {
            buttons[i].interactable = true;
        }

    }

    
}
