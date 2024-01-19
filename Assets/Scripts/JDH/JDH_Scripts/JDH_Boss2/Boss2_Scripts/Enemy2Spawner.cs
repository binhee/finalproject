using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Spawner : MonoBehaviour
{
    private Rigidbody2D rigid2D;

    [SerializeField]
    private GameObject[] Monsters;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private StageData stageData;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        StartCoroutine("SpawnMonsters");
    }

    private void FixedUpdate()
    {
        Vector2 direction = Player.transform.position - rigid2D.transform.position;
        Vector2 nextdirection = direction.normalized *Time.deltaTime;

        rigid2D.MovePosition(rigid2D.position + nextdirection);
        rigid2D.velocity = Vector2.zero;
    }

    private IEnumerator SpawnMonsters()
    {
        while(true)
        {
            float PositionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);

            Instantiate(Monsters[0], new Vector3(PositionX, stageData.LimitMax.y + 2f,0), Quaternion.identity);
            Instantiate(Monsters[1], new Vector3(PositionX, stageData.LimitMax.y + 2f, 0), Quaternion.identity);
            yield return new WaitForSeconds(1);

        }
    }
}
