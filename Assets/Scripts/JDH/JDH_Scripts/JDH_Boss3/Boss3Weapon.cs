using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Boss3AttackType { SingleToPlayer, CircleForPlayer };

public class Boss3Weapon : MonoBehaviour
{
    [SerializeField]
    private float attackRate;
    [SerializeField]
    private GameObject SingleBullet;
    [SerializeField]
    private Transform player;
    //�߻�� �Ѿ� ������Ʈ
    public GameObject Bullet;


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
        while(true)
        {
            Vector2 direction = player.transform.position - transform.position;
            GameObject bullet = Instantiate(SingleBullet,player.transform.position,Quaternion.identity);


            yield return null;
        }
    }

        private IEnumerator CircleForPlayer()
        {
            //Target�������� �߻�� ������Ʈ ����
            List<Transform> bullets = new List<Transform>();

        for (int i = 0; i < 360; i += 13)
        {
            //�Ѿ� ����
            GameObject temp = Instantiate(Bullet);

            //2���� ����
            Destroy(temp, 2f);

            //�Ѿ� ���� ��ġ�� (0,0) ��ǥ�� �Ѵ�.
            temp.transform.position = Vector2.zero;

            //?���Ŀ� Target���� ���ư� ������Ʈ ����
            bullets.Add(temp.transform);

            //Z�� ���� ���ؾ� ȸ���� �̷�����Ƿ�, Z�� i�� �����Ѵ�.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }

        //�Ѿ��� Target �������� �̵���Ų��.
        StartCoroutine(BulletToTarget(bullets));
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator BulletToTarget(IList<Transform> objects)
    {
        //0.5�� �Ŀ� ����
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < objects.Count; i++)
        {
            //���� �Ѿ��� ��ġ���� �÷����� ��ġ�� ���Ͱ��� �y���Ͽ� ������ ����
            Vector3 targetDirection = player.transform.position - objects[i].position;

            //x,y�� ���� �����Ͽ� Z���� ������ ������. -> ~�� ������ ����
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

            //Target �������� �̵�
            objects[i].rotation = Quaternion.Euler(0, 0, angle);
        }

        //������ ����
        objects.Clear();
    }
}

