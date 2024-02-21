using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject hiddenObject;
    public GameObject Trap1Object;
    public GameObject Trap2Object;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Break();
        }
    }

    private void Break()
    {
        if (hiddenObject != null)
        {
            hiddenObject.SetActive(true);
            Trap1Object.SetActive(false);
            Trap2Object.SetActive(false);
        }

        Destroy(gameObject);
    }
}
