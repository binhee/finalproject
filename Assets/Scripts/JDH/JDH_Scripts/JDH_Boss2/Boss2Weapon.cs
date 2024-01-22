using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyAttackType { Laser=0, Boom }
public class Boss2Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject LaserLine;
    [SerializeField]
    private GameObject Enemylaser;
    [SerializeField]
    private float attackRate;

    [SerializeField]
    private GameObject BoomAttack;

    //private void Start()
    //{
    //    StartCoroutine("Laser");
    //}
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
        GameObject cloneLine = null;
        GameObject cloneLaser = null;
      
        while (true)
        {

            GameObject Line = Instantiate(LaserLine, new Vector3(0, -4, 0), Quaternion.identity);
            //cloneLine = Instantiate(LaserLine, transform.position, Quaternion.identity);
            //cloneLine.GetComponent<Movement2D>().MoveTo(new Vector3(-0.7f, -1, 0));

            //cloneLine = Instantiate(LaserLine, transform.position, Quaternion.identity);
            //cloneLine.GetComponent<Movement2D>().MoveTo(new Vector3(0.7f, -1, 0));

            yield return new WaitForSeconds(1f);

            Destroy(Line);

            Instantiate(Enemylaser, transform.position, Quaternion.identity);
            cloneLaser = Instantiate(Enemylaser,transform.position, Quaternion.identity);
            cloneLaser.GetComponent<Movement2D>().MoveTo(new Vector3(-0.7f, -1, 0));

            cloneLaser =Instantiate(Enemylaser,transform.position,Quaternion.identity);
            cloneLaser.GetComponent<Movement2D>().MoveTo(new Vector3(0.7f, -1, 0));



            Debug.Log("Laser");

          
            yield return new WaitForSeconds(attackRate);

        }
    }
}
