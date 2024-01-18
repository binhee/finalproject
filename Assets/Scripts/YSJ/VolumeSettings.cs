using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider BGMSlider;

    //private void Start()
    //{
    //    if (PlayerPrefs.HasKey("BGMVolume"))
    //    {
    //        LoadVolume();
    //    }
    //    else
    //    {
    //        SetBGMVolume();     // �����̴� ���� ����� �ͼ� ȣȯ.
    //    }        
    //}
    public void SetBGMVolume()
    {
        float volume = BGMSlider.value;
        audioMixer.SetFloat("BGM", Mathf.Log10(volume)*20);
        //PlayerPrefs.SetFloat("BGMVolume", volume);  //BGMVolume �̸����� �����̴� ���� ����
    }

    //private void LoadVolume()
    //{
    //    //�����̴� ������ BGMVolume �̸����� ������ ���� ���Ͻ� ��.
    //    BGMSlider.value = PlayerPrefs.GetFloat("BGMvolume");

    //    SetBGMVolume();
    //}
}
