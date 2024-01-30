using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    StageData stageData;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private float SpawnTime;
    [SerializeField]
    private int maxEnemyCount = 0;
    [SerializeField]
    private GameObject textBoss;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private GameObject panelBossHp;


    private void Awake()
    {
        textBoss.SetActive(false);
        panelBossHp.SetActive(false);
        boss.SetActive(false);
        StartCoroutine("SpawnBoss");
    }

  

    private IEnumerator SpawnBoss()
    {
        textBoss.SetActive (true);
        yield return new WaitForSeconds(1.0f);
        textBoss.SetActive(false);
        panelBossHp.SetActive (true);
        boss.SetActive (true);
        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);
    }
}
