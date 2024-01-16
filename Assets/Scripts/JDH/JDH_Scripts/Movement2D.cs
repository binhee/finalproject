using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 moveDIrection = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDIrection * speed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDIrection = direction;
    }

}
