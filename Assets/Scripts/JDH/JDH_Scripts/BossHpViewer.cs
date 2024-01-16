using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpViewer : MonoBehaviour
{
    [SerializeField]
    private BossHp bossHp;
    private Slider slider;
   
    // Start is called before the first frame update
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = bossHp.CurrentHP / bossHp.MaxHP;
    }
}
