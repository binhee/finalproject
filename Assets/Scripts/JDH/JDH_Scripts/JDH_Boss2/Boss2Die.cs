using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Die : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionDie;
    [SerializeField]
    private GameObject ClearPanel;
    [SerializeField]
    private GameObject GameOverPanel;
    [SerializeField]
    private int Boss2Gold = 15000;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    public void Boss2OnDie()
    {
        Instantiate(explosionDie,transform.position, Quaternion.identity);

        Destroy(gameObject);
        //playerController.Gold += Boss2Gold;

        ClearPanel.SetActive(true);
    }
}
