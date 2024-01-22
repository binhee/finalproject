using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyAttackType { Laser, Boom }
public class Boss2Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject LaserLine;
    [SerializeField]
    private GameObject Enemylaser;
    [SerializeField]
    private float attackRate;
    private void Awake()
    {
        StartCoroutine("Laser");
    }
    public void StartAttack(EnemyAttackType enemyAttackType)
    {
        StartCoroutine(enemyAttackType.ToString());
    }

    public void StopAttack(EnemyAttackType enemyAttackType)
    {
        StopCoroutine(enemyAttackType.ToString());
    }

    private IEnumerator Laser()
    {
       
        while (true)
        {
            Debug.Log("�׽�Ʈ");
            GameObject Line = Instantiate(LaserLine, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Debug.Log("�׽�Ʈ1");
            Destroy(Line);
            Debug.Log("�׽�Ʈ2");
            Instantiate(Enemylaser, transform.position, Quaternion.identity);
            Debug.Log(attackRate);
            yield return new WaitForSeconds(attackRate);

            Debug.Log("�׽�Ʈ3");
        }
    }
   
}
