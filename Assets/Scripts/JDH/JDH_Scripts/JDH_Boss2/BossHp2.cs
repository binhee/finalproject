using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp2 : MonoBehaviour
{
        [SerializeField]
        private float maxHP2 = 1000;
        private float currentHP2;
        private SpriteRenderer spriterenderer;
        private Boss2Die bossDie;

        public float MaxHP2 => maxHP2;
        public float CurrentHP2 => currentHP2;
        private void Awake()
        {
            bossDie = GetComponent<Boss2Die>();
            currentHP2 = maxHP2;
            spriterenderer = GetComponent<SpriteRenderer>();
        }

        public void TakeDamage(float damage)
        {
            currentHP2 -= damage;

            StopCoroutine("HitColor");
            StartCoroutine("HitColor");

            if (currentHP2 <= 0)
            {
                bossDie.Boss2OnDie();
            }
        }

        private IEnumerator HitColor()
        {
            spriterenderer.color = Color.red;
            yield return new WaitForSeconds(0.05f);
            spriterenderer.color = Color.white;
        }
    }


