using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2HpViewer : MonoBehaviour
{
    [SerializeField]
    private BossHp2 bossHp2;
    private Slider slider;

    // Start is called before the first frame update
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = bossHp2.CurrentHP2 / bossHp2.MaxHP2;
    }
}
