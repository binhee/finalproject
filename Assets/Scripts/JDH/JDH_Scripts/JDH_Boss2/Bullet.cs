using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Bullet : MonoBehaviour
{

    public float Speed = 10f;

    private void Start()
    {
        //�������κ��� 2�� �� ����
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        //�ι�° �Ķ���Ϳ� Space.World�� �������ν� Rotation�� ���� ���� ������ ������
        transform.Translate(Vector2.right * (Speed * Time.deltaTime), Space.Self);
    }
}

