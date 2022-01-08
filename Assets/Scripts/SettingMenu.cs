using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectSlider;
    private float backgroundFloat, soundEffectFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] SoundEffectAudio;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        Debug.Log("firstPlayInt: " + firstPlayInt);
        if(firstPlayInt == 0)
        {
            backgroundFloat = .125f;
            soundEffectFloat = .75f;
            backgroundSlider.value = backgroundFloat;
            soundEffectSlider.value = soundEffectFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
            Debug.Log("FirstPlay: "+ FirstPlay);
            Debug.Log("FirstPlay: " + PlayerPrefs.GetInt(FirstPlay));
        }
        else
        {
            Debug.Log("NotFirst");
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectFloat =  PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectSlider.value = soundEffectFloat;
            Debug.Log("Get: " + backgroundFloat + "|" + soundEffectFloat);
        }
    }

    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectSlider.value);
        Debug.Log(backgroundFloat + "|" +  soundEffectFloat);
    }

    void OnApplicationFocus(bool infocus)
    {
        if (!infocus)
        {
            SaveSoundSetting();
            Debug.Log("Saved");
        }
    }

    public void UpdateSound()
    {
        Debug.Log("Update");
        backgroundAudio.volume = backgroundSlider.value;
        for(int i = 0; i < SoundEffectAudio.Length; i++)
        {
            SoundEffectAudio[i].volume = soundEffectSlider.value;
        }
        SaveSoundSetting();
    }
}
