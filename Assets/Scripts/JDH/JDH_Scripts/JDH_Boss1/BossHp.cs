using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 1000;
    private float currentHP;
    private SpriteRenderer spriterenderer;
    private Boss boss;
    private SoundManager soundmanager;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;
    private void Awake()
    {
        soundmanager = GetComponent<SoundManager>();
        boss = GetComponent<Boss>();
        currentHP = maxHP;
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        StopCoroutine("HitColor");
        StartCoroutine("HitColor");

        if(currentHP <=0)
        {
           boss.OnDie();
          
        }
    }

    private IEnumerator HitColor()
    {
        spriterenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spriterenderer.color = Color.white;
    }
}
