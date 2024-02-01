using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Vector2 startPoint;
    public int playerGold;
    public int playerDamage;

    public static PlayerManager instance;
    public GameObject player;

    private void Awake()
    {
        FindPlayer();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public GameObject FindPlayer()
    {
        return GameObject.Find("Player");
    }
}
