using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Spawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject[] Enemys;
    [SerializeField]
    private GameObject boss2;

    [SerializeField]
    private GameObject Boss2PanelHp;
    [SerializeField]
    private GameObject Boss2textWarning;

    [SerializeField]
    private float SpawnDelay;
    [SerializeField]
    private int maxEnemyCounts = 20;


    private void Start()
    {
        Boss2textWarning.SetActive(false);
        Boss2PanelHp.SetActive(false);
        //boss2.SetActive(false);
        
        StartCoroutine("Boss2Spawn");
    }  

    //private IEnumerator Spawn2Enemys()
    //{
    //    int currentEnemy = 0;

    //    while (true)
    //    {
    //        float PositionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
    //        float PositionsX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
    //        Vector3 Position = new Vector3(PositionX, stageData.LimitMax.y, 0);
    //        Vector3 Positions = new Vector3(PositionsX, stageData.LimitMax.y, 0);
    //        Instantiate(Enemys[0], Position, Quaternion.identity);
    //        yield return new WaitForSeconds(2f);
    //        Instantiate(Enemys[1], Positions, Quaternion.identity);

    //        currentEnemy++;
    //        if (currentEnemy == maxEnemyCounts)
    //        {
    //            StartCoroutine("Boss2Spawn");
    //            break;
    //        }
    //        yield return new WaitForSeconds(SpawnDelay);
    //    }
    //}

    private IEnumerator Boss2Spawn()
    {
        yield return new WaitForSeconds(2f);
        Boss2textWarning.SetActive(true);
        yield return new WaitForSeconds(1f);

        Boss2textWarning.SetActive(false);
        Boss2PanelHp.SetActive(true);
        boss2.SetActive(true);
        boss2.GetComponent<Boss2>().ChangePattern(Boss2State.MoveApeear);
    }
}
