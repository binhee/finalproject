using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUSe : MonoBehaviour
{
    [SerializeField]
    private KeyCode AttackKey = KeyCode.Space;
    private Movement2D movement2D;
    private Weapon weapon;

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
        movement2D = GetComponent<Movement2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x,y, 0));

        if(Input.GetKey(AttackKey))
        {
            weapon.StartFiring();
        }
        else if(Input.GetKeyUp(AttackKey))
        {
            weapon.StopFiring();
        }
    }
}
