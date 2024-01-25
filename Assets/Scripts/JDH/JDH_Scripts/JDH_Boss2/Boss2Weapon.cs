using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyAttackType { Laser=0, TriangleLaser, Boom }
public class Boss2Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject LaserLine;
    [SerializeField]
    private GameObject Enemylaser;
    [SerializeField]
    private float attackRate;

    [SerializeField]
    private GameObject boomPrefab;
    [SerializeField]
    private GameObject boomEffect;
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
           

            yield return new WaitForSeconds(1f);

            Destroy(Line);

            Instantiate(Enemylaser, transform.position, Quaternion.identity);
            cloneLaser = Instantiate(Enemylaser, transform.position, Quaternion.identity);
            cloneLaser.GetComponent<Movement2D>().MoveTo(new Vector3(-1f, -1, 0));
            cloneLaser = Instantiate(Enemylaser, transform.position, Quaternion.identity);
            cloneLaser.GetComponent<Movement2D>().MoveTo(new Vector3(1f, -1, 0));

            Debug.Log("Laser");

            yield return new WaitForSeconds(attackRate);

        }
    }

    private IEnumerator TriangleLaser()
    {
        GameObject cloneLine = null;
        GameObject cloneLaser = null;

        while (true)
        {

            //GameObject Line = Instantiate(LaserLine,new Vector3(transform.position.x,-3,0), Quaternion.identity);

            //cloneLine = Instantiate(LaserLine, transform.position, Quaternion.identity);
            //cloneLine.GetComponent<Movement2D>().MoveTo(new Vector3(-0.8f, 0, 0));
            //cloneLine = Instantiate(Enemylaser, transform.position, Quaternion.identity);
            //cloneLine.GetComponent<Movement2D>().MoveTo(new Vector3(-0.4f, 0, 0));

            //cloneLine = Instantiate(LaserLine, transform.position, Quaternion.identity);
            //cloneLine.GetComponent<Movement2D>().MoveTo(new Vector3(0.8f, 0, 0));
            //cloneLine = Instantiate(Enemylaser, transform.position, Quaternion.identity);
            //cloneLine.GetComponent<Movement2D>().MoveTo(new Vector3(0.4f, 0, 0));

            //Debug.Log("Line");

            yield return new WaitForSeconds(1f);

            //Destroy(Line);

            Instantiate(Enemylaser, transform.position, Quaternion.identity);
            cloneLaser = Instantiate(Enemylaser, transform.position, Quaternion.identity);
            cloneLaser.GetComponent<Movement2D>().MoveTo(new Vector3(-1f, -1, 0));
            cloneLaser = Instantiate(Enemylaser, transform.position, Quaternion.identity);
            cloneLaser.GetComponent<Movement2D>().MoveTo(new Vector3(-0.5f, -1, 0)); 

            cloneLaser = Instantiate(Enemylaser, transform.position, Quaternion.identity);
            cloneLaser.GetComponent<Movement2D>().MoveTo(new Vector3(1f, -1, 0));
            cloneLaser = Instantiate(Enemylaser, transform.position, Quaternion.identity);
            cloneLaser.GetComponent<Movement2D>().MoveTo(new Vector3(0.5f, -1, 0));

            Debug.Log("Laser1");


            yield return new WaitForSeconds(attackRate);

        }
    }

    private IEnumerator Boom()
    {
        GameObject boom = null;
        GameObject Effect = null;
        while(true)
        {
            //Instantiate(boomPrefab, transform.position, Quaternion.identity);
            boom = Instantiate(boomPrefab, transform.position, Quaternion.identity);
            //boom.GetComponent<Movement2D>().MoveTo(new Vector3(0, -6, 0));
          
            yield return new WaitForSeconds(1f);
            Effect = Instantiate(boomEffect, boom.transform.position, Quaternion.identity);
            Destroy(boom);

            yield return new WaitForSeconds(attackRate);
            Destroy(Effect);


        }
    }
}
