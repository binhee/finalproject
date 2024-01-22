using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Spawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject Enemys;
    [SerializeField]
    private GameObject Boss2;

    [SerializeField]
    private GameObject Boss2PanelHp;
    [SerializeField]
    private GameObject Boss2textWarning;

    [SerializeField]
    private float SpawnDelay;
    [SerializeField]
    private int maxEnemyCounts = 20;


    private void Awake()
    {
        Boss2textWarning.SetActive(false);
        Boss2PanelHp.SetActive(false);
        Boss2.SetActive(false);
        
        StartCoroutine("Spawn2Enemys");
    }  

    private IEnumerator Spawn2Enemys()
    {
        int currentEnemy = 0;

        while (true)
        {
            float PositionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            Vector3 Position = new Vector3(PositionX, stageData.LimitMax.y, 0);
            Instantiate(Enemys, Position, Quaternion.identity);

            currentEnemy++;
            if (currentEnemy == maxEnemyCounts)
            {
                StartCoroutine("Boss2Spawn");
                break;
            }
            yield return new WaitForSeconds(SpawnDelay);
        }
    }

    private IEnumerator Boss2Spawn()
    {
        Boss2textWarning.SetActive(true);
        yield return new WaitForSeconds(1f);

        Boss2textWarning.SetActive(false);
        Boss2PanelHp.SetActive(true);
        Boss2.SetActive(true);
    }
}
