using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    public Slider backgroundSlider, soundEffectSlider;
    private float backgroundFloat, soundEffectFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] SoundEffectAudio;

    void Awake()
    {
        ContinueSettings();
    }

    // Update is called once per frame
    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
        backgroundSlider.value = backgroundFloat;
        soundEffectSlider.value = soundEffectFloat;
        Debug.Log("Get for next floor");
        backgroundAudio.volume = backgroundFloat;
        for (int i = 0; i < SoundEffectAudio.Length; i++)
        {
            SoundEffectAudio[i].volume = soundEffectFloat;
        }
    }
    public void UpdateSound()
    {
        Debug.Log("Update");
        backgroundAudio.volume = backgroundSlider.value;
        for (int i = 0; i < SoundEffectAudio.Length; i++)
        {
            SoundEffectAudio[i].volume = soundEffectSlider.value;
        }
        SaveSoundSetting();
    }

    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectSlider.value);
    }
}
