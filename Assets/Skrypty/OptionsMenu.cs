using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume",volume);
        PlayerPrefs.Save();
    }
    private void Start()
    {
        float music = PlayerPrefs.GetFloat("volume", 0f);
        slider.value = PlayerPrefs.GetFloat("volume", 0f);
        SetVolume(music);
    }
}
