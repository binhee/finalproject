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
        instance = this;
    }
}
