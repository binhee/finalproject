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
    //발사될 총알 오브젝트
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
        //Target방향으로 발사될 오브젝트 수록
        List<Transform> bullets = new List<Transform>();
        while (true)
        {
            for (int i = 0; i < 360; i += 13)
            {

                //총알 생성
                GameObject temp = Instantiate(Bullet1);

                //2초후 삭제
                //Destroy(temp, 10f);

                //총알 생성 위치를 (0,0) 좌표로 한다.
                temp.transform.position = transform.position;

                //?초후에 Target에게 날아갈 오브젝트 수록
                bullets.Add(temp.transform);

                //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
                temp.transform.rotation = Quaternion.Euler(0, 0, i);


            }
            yield return new WaitForSeconds(attackRate);
            //총알을 Target 방향으로 이동시킨다.
            StartCoroutine(BulletToTarget(bullets));
            yield return new WaitForSeconds(1.2f);

        }

        ////총알을 Target 방향으로 이동시킨다.
        //StartCoroutine(BulletToTarget(bullets));
        //yield return new WaitForSeconds(0.2f);

    }

    private IEnumerator BulletToTarget(IList<Transform> objects)
    {
        //0.5초 후에 시작
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < objects.Count; i++)
        {
            //현재 총알의 위치에서 플레이의 위치의 벡터값을 뻴셈하여 방향을 구함
            Vector3 targetDirection = PlayerManager.instance.FindPlayer().transform.position - objects[i].position;

            //x,y의 값을 조합하여 Z방향 값으로 변형함. -> ~도 단위로 변형
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

            //Target 방향으로 이동
            objects[i].rotation = Quaternion.Euler(0, 0, angle);
        }

        //데이터 해제
        objects.Clear();
    }
}


