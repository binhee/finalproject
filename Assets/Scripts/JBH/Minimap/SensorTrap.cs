using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SensorTrap : MonoBehaviour
{
    public GameObject trapObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (trapObject != null)
            {
                trapObject.SetActive(true);
            }
        }
    }
}
