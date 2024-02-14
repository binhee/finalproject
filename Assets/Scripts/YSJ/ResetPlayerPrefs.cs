using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.DeleteKey("ReachedIndex");
        PlayerPrefs.DeleteKey("UnlockedLevel");
    }
}
