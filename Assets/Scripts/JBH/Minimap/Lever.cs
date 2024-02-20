using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject Player;

    private bool hasActivatedObject2 = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject == Player))
        {
            Vector2 newPosition = object1.transform.position;
            newPosition.y -= 1;
            object1.transform.position = newPosition;

            object2.SetActive(true);
        }
    }
}
