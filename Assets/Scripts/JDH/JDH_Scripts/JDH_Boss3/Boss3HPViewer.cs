using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss3HpViewer : MonoBehaviour
{
    [SerializeField]
    private Boss3HP bossHp3;
    private Slider slider;

    // Start is called before the first frame update
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = bossHp3.CurrentHP3 / bossHp3.MaxHP3;
    }
}

