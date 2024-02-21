using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    public EnemyPoolManager enemyPoolManger;
    [SerializeField]
    private StageData stageData;
   
    [SerializeField]
    private float minSpawnTime = 1.0f;
    [SerializeField]
    private float maxSpawnTime = 4.0f;

    private void Awake()
    {
        StartCoroutine("SpawnMeteorite");
    }

    private IEnumerator SpawnMeteorite()
    {
        while (true)
        {
            float PositionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            GameObject alertLineClone = enemyPoolManger.MakeObj("alertLine");
            alertLineClone.transform.position = new Vector3(PositionX, 0, 0);
            yield return new WaitForSeconds(1.0f);

          
            alertLineClone.SetActive(false);
           
         
            Vector3 meteoritePosition = new Vector3(PositionX, stageData.LimitMax.y + 2.0f, 0);
          
            GameObject MeteoEnemy =enemyPoolManger.MakeObj("MeteoriteEnemy");
            MeteoEnemy.transform.position = meteoritePosition;
           


            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
        }
    }

}
