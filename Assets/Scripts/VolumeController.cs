using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] Slider VolumeSlider;
    void Start()
    {
        LoadValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateVolume()
    {
        float VolumeValue = VolumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", VolumeValue);
        LoadValues();
    }
    public void LoadValues()
    {
        float VolumeValue = PlayerPrefs.GetFloat("VolumeValue");
        VolumeSlider.value = VolumeValue;
        AudioListener.volume = VolumeValue;
    }
}
