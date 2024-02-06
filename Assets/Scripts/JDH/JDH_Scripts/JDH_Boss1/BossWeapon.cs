using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { CircleFire = 0, SingleFireToCenterPosition }

public class BossWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyProjectile;

    public EnemyPoolManager enemyPoolManger;


    public void StartFiring(AttackType attackType)
    {
        StartCoroutine(attackType.ToString());
    }

    public void StopFiring(AttackType attackType)
    {
        StopCoroutine(attackType.ToString());
    }

    private IEnumerator CircleFire()
    {
        float attackRate = 1f;
        int count = 30;
        float intervalAngle = 360 / count;
        float weightAngle = 0;

        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                Debug.Log("h");
                GameObject clone = enemyPoolManger.MakeObj("EnemyProjectile");
                Debug.Log("hhh");
                clone.transform.position = transform.position;
                /*Instantiate(enemyProjectile,transform.position, Quaternion.identity);*/

                float angle = weightAngle + intervalAngle * i;
                float x = Mathf.Cos(angle * Mathf.PI / 180f);
                float y = Mathf.Sin(angle * Mathf.PI / 180f);

                clone.GetComponent<Movement2D>().MoveTo(new Vector2(x, y));
            }
            weightAngle += 1;

            Debug.Log("hh");
            yield return new WaitForSeconds(attackRate);
        }
    }

    private IEnumerator SingleFireToCenterPosition()
    {
        Vector3 targetPosition = Vector3.zero;
        float attackRate = 0.5f;

        while (true)
        {
            GameObject Leftclone = enemyPoolManger.MakeObj("EnemyProjectile");
            Leftclone.transform.position = transform.position;
            /* Instantiate(enemyProjectile,transform.position, Quaternion.identity); */
            /*(PlayerManager.instance.FindPlayer().transform.position*/
            Vector3 Leftdirection = (targetPosition - Leftclone.transform.position).normalized;
            Leftclone.GetComponent<Movement2D>().MoveTo(Leftdirection);

            GameObject Rightclone = enemyPoolManger.MakeObj("EnemyProjectile");
            Rightclone.transform.position = transform.position;
            Vector3 Rightdirection = (targetPosition + Rightclone.transform.position).normalized;
            Rightclone.GetComponent<Movement2D>().MoveTo(Rightdirection);


            yield return new WaitForSeconds(attackRate);
        }
    }
}

