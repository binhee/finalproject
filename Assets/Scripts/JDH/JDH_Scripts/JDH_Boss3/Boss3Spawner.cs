using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Spawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject boss3;

    [SerializeField]
    private GameObject Boss3PanelHp;
    [SerializeField]
    private GameObject Boss3textWarning;

    [SerializeField]
    private float SpawnDelay;
    [SerializeField]
    private int maxEnemyCounts = 20;


    private void Start()
    {
        Boss3textWarning.SetActive(false);
        Boss3PanelHp.SetActive(false);
        boss3.SetActive(false);

        StartCoroutine("Boss3Spawn");
    }


    private IEnumerator Boss3Spawn()
    {
        Boss3textWarning.SetActive(true);
        yield return new WaitForSeconds(1f);

        Boss3textWarning.SetActive(false);
        Boss3PanelHp.SetActive(true);
        boss3.SetActive(true);
        boss3.GetComponent<Boss3>().ChangePattern(Boss3State.Pattern01);
    }
}

