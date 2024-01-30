using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubArrowLauncher : MonoBehaviour
{
    public RangedAttackData rangedAttackData;
    public float shotDelay;

    private Vector2 mousePos;
    private float time;
    void Update()
    {
        SubArrowShooting();
    }
    void SubArrowShooting()
    {
        time += Time.deltaTime;
        mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (time > shotDelay)
        {
            time = 0;
            Vector2 pos = transform.position;
            ProjectileManager.Instance.ShootBullet(pos , mousePos - pos , rangedAttackData);
        }
    }
}
