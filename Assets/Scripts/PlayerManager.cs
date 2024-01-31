using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Vector2 startPoint;
    public int playerGold;
    public int playerDamage;
    
    public static PlayerManager instance;
    

    private void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        FindPlayer();
    }
    public GameObject FindPlayer()
    {
        return GameObject.Find("Player");
    }
}
