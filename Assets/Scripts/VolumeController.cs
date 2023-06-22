using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] Slider VolumeSlider;

    private void Start()
    {
        LoadValues();
    }

    public void UpdateVolume()
    {
        float volumeValue = VolumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue", 0.7f);
        VolumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
