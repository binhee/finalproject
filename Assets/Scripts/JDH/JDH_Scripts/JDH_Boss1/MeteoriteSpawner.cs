using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject alertline;
    [SerializeField]
    private GameObject Meteorite;
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
        while(true)
        {
            float PositionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            GameObject alertLineClone = Instantiate(alertline,new Vector3(PositionX, 0, 0),Quaternion.identity);
            yield return new WaitForSeconds(1.0f);

            Destroy(alertLineClone);

            Vector3 meteoritePosition = new Vector3(PositionX, stageData.LimitMax.y + 2.0f, 0);
            Instantiate(Meteorite,meteoritePosition, Quaternion.identity);

            float spawnTime =Random.Range(minSpawnTime,maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
        }
    }

}
