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
    //        SetBGMVolume();     // 슬라이더 값과 오디오 믹서 호환.
    //    }        
    //}
    public void SetBGMVolume()
    {
        float volume = BGMSlider.value;
        audioMixer.SetFloat("BGM", Mathf.Log10(volume)*20);
        //PlayerPrefs.SetFloat("BGMVolume", volume);  //BGMVolume 이름으로 슬라이더 값을 저장
    }

    //private void LoadVolume()
    //{
    //    //슬라이더 볼륨을 BGMVolume 이름으로 저장한 값과 동일시 함.
    //    BGMSlider.value = PlayerPrefs.GetFloat("BGMvolume");

    //    SetBGMVolume();
    //}
}
