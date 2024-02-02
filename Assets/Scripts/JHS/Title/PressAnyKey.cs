using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    public SceneChange SceneChanger;
    public bool onAnyUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           SceneChanger.MainSceneLoad();
        }
    }
 
}
