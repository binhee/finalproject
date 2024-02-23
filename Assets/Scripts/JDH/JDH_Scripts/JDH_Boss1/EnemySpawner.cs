using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    StageData stageData;
    //[SerializeField]
    //private GameObject enemy;
    [SerializeField]
    private float SpawnTime;
    //[SerializeField]
    //private int maxEnemyCount = 100;
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

    //private IEnumerator SpawnEnemy()
    //{
    //    int currentEnemyCount = 0;
    //    while (true)
    //    {
    //        float PositionY = Random.Range(stageData.LimitMin.y, stageData.LimitMax.y);
    //        Instantiate(enemy, new Vector3(stageData.LimitMax.x - 1f, PositionY), Quaternion.identity);

    //        currentEnemyCount++;

    //        if (currentEnemyCount == maxEnemyCount)
    //        {
    //            StartCoroutine("SpawnBoss");
    //            break;
    //        }
    //        yield return new WaitForSeconds(SpawnTime);
    //    }
       
    //}

    private IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(4f);
        textBoss.SetActive (true);
        yield return new WaitForSeconds(1.0f);
        textBoss.SetActive(false);
        SoundManager.SoundInstance.PlaySFX(SoundManager.SoundInstance.Boss1AppearSound);
        panelBossHp.SetActive (true);
        boss.SetActive (true);
        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);
    }
}
