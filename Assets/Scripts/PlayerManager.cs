using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Vector2 startPoint;
    public int playerGold;

    public static PlayerManager instance;

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
