using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2Die : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionDie;
    [SerializeField]
    private GameObject ClearPanel;
   
    [SerializeField]
    private int Boss2Gold = 1500;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    public void Boss2OnDie()
    {
        Instantiate(explosionDie,transform.position, Quaternion.identity);
        ClearPanel.SetActive(true);
        gameObject.SetActive(false);
        PlayerManager.instance.playerGold += Boss2Gold;

        PlayerPrefs.SetInt("Gold",PlayerManager.instance.playerGold);

    }

}
