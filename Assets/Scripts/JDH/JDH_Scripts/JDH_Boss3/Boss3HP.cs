using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3HP : MonoBehaviour
{
    [SerializeField]
    private float maxHP3 = 1000;
    private float currentHP3;
    private SpriteRenderer spriterenderer;
    private Boss3Die boss3Die;

    public float MaxHP3 => maxHP3;
    public float CurrentHP3 => currentHP3;
    private void Awake()
    {
        boss3Die = GetComponent<Boss3Die>();
        currentHP3 = maxHP3;
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHP3 -= damage;

        StopCoroutine("HitColor");
        StartCoroutine("HitColor");

        if (currentHP3 <= 0)
        {
            boss3Die.Boss3OnDie();
        }
    }

    private IEnumerator HitColor()
    {
        spriterenderer.color = Color.magenta;
        yield return new WaitForSeconds(0.05f);
        spriterenderer.color = Color.white;
    }
}


