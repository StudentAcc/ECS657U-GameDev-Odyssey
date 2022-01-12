using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";

    private static readonly string MasterPref = "MasterPref";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";

    private int firstPlayInt;

    public Slider masterSlider, backgroundSlider, soundEffectsSlider;
    private float masterFloat, backgroundFloat, soundEffectsFloat;

    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;

    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayInt == 0)
        {
            masterFloat = 0.5f;
            backgroundFloat = 0.205f;
            soundEffectsFloat = 0.605f;

            masterSlider.value = masterFloat;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;


            PlayerPrefs.SetFloat(MasterPref, masterFloat);
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);


            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            masterFloat = PlayerPrefs.GetFloat(MasterPref);
            masterSlider.value = masterFloat;

            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;

            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MasterPref, masterSlider.value);
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;
        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
        AudioListener.volume = masterSlider.value;
    }

    public float getSoundEffectsVolume()
    {
        return soundEffectsSlider.value;
    }
}
