using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubArrowLauncher : MonoBehaviour
{
    public RangedAttackData rangedAttackData;
    public float shotDelay;
    public Vector3 pos;

    private Vector2 mousePos;
    private float time;
    public GameObject player;
    void Update()
    {
        SubArrowShooting();
        SetPosition();
    }
    void SubArrowShooting()
    {
        time += Time.deltaTime;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (time > shotDelay)
        {
            time = 0;
            Vector2 pos = transform.position;
            ProjectileManager.Instance.ShootBullet(pos, (mousePos - pos).normalized, rangedAttackData);
        }
    }
    void SetPosition()
    {
        if (player == null)
        {
            player = PlayerManager.instance.FindPlayer();
        }
        transform.position = player.transform.position - pos;
    }
    public void PosByGrade(int grade)
    {
        switch (grade)
        {
            case 0:
                break;
            case 1:
                pos = new Vector3(1.5f, -1, 0);
                break;
            case 2:
                pos = new Vector3(1, -0.5f, 0);
                break;
            case 3:
                pos = new Vector3(1.5f, -0.5f, 0);
                break;
        }
    }
}
