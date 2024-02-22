using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum Boss3AttackType { SingleToPlayer, AngleLaser, CircleForPlayer };

public class Boss3Weapon : MonoBehaviour
{
    [SerializeField]
    private float attackRate = 2f;
    [SerializeField]
    private int PerAngle;
    [SerializeField]
    private int speed;
    [SerializeField]
    private int rotateTime;
    [SerializeField]
    private GameObject LaserGroup;
    //�߻�� �Ѿ� ������Ʈ
    public GameObject Bullet;
    public GameObject Bullet1;

    private void Awake()
    {
        LaserGroup.SetActive(false);
    }
    public void StartAttack(Boss3AttackType enemyAttackType)
    {
        StartCoroutine(enemyAttackType.ToString());
    }

    public void StopAttack(Boss3AttackType enemyAttackType)
    {
        StopCoroutine(enemyAttackType.ToString());
    }

    private IEnumerator SingleToPlayer()
    {
       
        
        while (true)
        {            
            GameObject bullet = Instantiate(Bullet,transform.position,Quaternion.identity);
            Vector3 TargetPos = PlayerManager.instance.FindPlayer().transform.position - bullet.transform.position;
            Vector3 direction = TargetPos.normalized;
            bullet.GetComponent<Movement2D>().MoveTo(direction);

            yield return new WaitForSeconds(attackRate);
        }
    }

    

    private IEnumerator AngleLaser()
    {
        
        while (true)
        {
            LaserGroup.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            
            LaserGroup.transform.Rotate(Vector3.forward * PerAngle *speed* Time.deltaTime);

            
            yield return new WaitForSeconds(2f);

            LaserGroup.SetActive(false);

            yield return new WaitForSeconds(1f);
            
            }
        }

    private IEnumerator CircleForPlayer()
    {
        //Target�������� �߻�� ������Ʈ ����
        List<Transform> bullets = new List<Transform>();
        while (true)
        {
            for (int i = 0; i < 360; i += 13)
            {

                //�Ѿ� ����
                GameObject temp = Instantiate(Bullet1);

                //2���� ����
                //Destroy(temp, 10f);

                //�Ѿ� ���� ��ġ�� (0,0) ��ǥ�� �Ѵ�.
                temp.transform.position = transform.position;

                //?���Ŀ� Target���� ���ư� ������Ʈ ����
                bullets.Add(temp.transform);

                //Z�� ���� ���ؾ� ȸ���� �̷�����Ƿ�, Z�� i�� �����Ѵ�.
                temp.transform.rotation = Quaternion.Euler(0, 0, i);


            }
            yield return new WaitForSeconds(attackRate);
            //�Ѿ��� Target �������� �̵���Ų��.
            StartCoroutine(BulletToTarget(bullets));
            yield return new WaitForSeconds(1.2f);

        }

        ////�Ѿ��� Target �������� �̵���Ų��.
        //StartCoroutine(BulletToTarget(bullets));
        //yield return new WaitForSeconds(0.2f);

    }

    private IEnumerator BulletToTarget(IList<Transform> objects)
    {
        //0.5�� �Ŀ� ����
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < objects.Count; i++)
        {
            //���� �Ѿ��� ��ġ���� �÷����� ��ġ�� ���Ͱ��� �y���Ͽ� ������ ����
            Vector3 targetDirection = PlayerManager.instance.FindPlayer().transform.position - objects[i].position;

            //x,y�� ���� �����Ͽ� Z���� ������ ������. -> ~�� ������ ����
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

            //Target �������� �̵�
            objects[i].rotation = Quaternion.Euler(0, 0, angle);
        }

        //������ ����
        objects.Clear();
    }
}


