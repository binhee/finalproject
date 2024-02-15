using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Die : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionDie;
    [SerializeField]
    private GameObject ClearPanel;

    [SerializeField]
    private int Boss3Gold = 3000;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    public void Boss3OnDie()
    {
        Instantiate(explosionDie, transform.position, Quaternion.identity);
        ClearPanel.SetActive(true);
        gameObject.SetActive(false);
        PlayerManager.instance.playerGold += Boss3Gold;

        PlayerPrefs.SetInt("Gold", PlayerManager.instance.playerGold);

    }

}