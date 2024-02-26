using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordAround : MonoBehaviour
{
    public Transform target;
    public float orbitSpeed;
    Vector3 offset;
   public  Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        transform.RotateAround(target.position, new Vector3(0,0,1), orbitSpeed * Time.deltaTime);
        offset = transform.position - target.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BossProjectile"))//적 총알 태그 넣기
        {
            collision.gameObject.SetActive(false);
        }
    }
}
