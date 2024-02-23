using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Vector2 startPoint;
    public int playerGold;
    public int playerDamage;

    public static PlayerManager instance;
    public GameObject player;
    public float playerProjectileAS;
    public bool isDoubleJump;

    private void Awake()
    {
        FindPlayer();
        playerProjectileAS = 10;
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
    private void Update()
    {
        if (player == null)
        {
            player = FindPlayer();
        }

        if (player != null)
        {
            StatsUpdate();
        }
    }
    public GameObject FindPlayer()
    {
        return GameObject.Find("Player");
    }
    public void StatsUpdate()
    {
        player.GetComponent<PlayerInputController>().itemDoubleJumping = isDoubleJump;
        player.GetComponent<CharacterStatsHandler>().CurrentStats.attackSO.speed = playerProjectileAS;
    }
}
