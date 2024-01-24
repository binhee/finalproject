using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasItem : MonoBehaviour
{
    public static CanvasItem instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
