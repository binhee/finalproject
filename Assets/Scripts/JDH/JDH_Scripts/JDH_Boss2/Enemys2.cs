using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys2 : MonoBehaviour
{
    public float speed;
    public float spawnTime;
    public Rigidbody2D target;

    private Rigidbody2D rigid;
    


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = target.position -rigid.position;
        Vector2 nextVec = direction.normalized * speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;  

    }
}
