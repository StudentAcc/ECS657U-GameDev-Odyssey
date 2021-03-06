using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagerMainMenu : MonoBehaviour
{
    //attempts to see if this run is the player's first time playing
    private static readonly string FirstPlayAudio = "FirstPlay";
    private int firstPlayInt;

    //initialises user's volume settings preferences
    private static readonly string MasterPref = "MasterPref";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";

    //initialises sliders to change volume of each noise
    public Slider masterSlider, backgroundSlider, soundEffectsSlider;
    private float masterFloat, backgroundFloat, soundEffectsFloat;

    //initialises music and sfx audio sounds
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;

    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlayAudio);
        //if this is player's first time playing, sets volume to default values and sets them in 'PlayerPrefs' variable
        if (firstPlayInt == 0)
        {
            masterFloat = 0.5f;
            backgroundFloat = 0.5f;
            soundEffectsFloat = 0.5f;

            masterSlider.value = masterFloat;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;


            PlayerPrefs.SetFloat(MasterPref, masterFloat);
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);


            PlayerPrefs.SetInt(FirstPlayAudio, -1);
        }
        //this isn't the player's first time playing, so load their volume settings
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

    //when the user is about to leave the scene, save the user's volume preferences
    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    //remembers the user's volume preferences and stores it in 'PlayerPrefs'
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MasterPref, masterSlider.value);
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
    }

    //updates the volume based on the slider values in the volume menu page
    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;
        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
        AudioListener.volume = masterSlider.value;
    }

    //returns the value of the sound effects slider
    public float getSoundEffectsVolume()
    {
        return soundEffectsSlider.value;
    }

    //pauses the music for when the user is in the main menu
    public void pauseMusic()
    {
        backgroundAudio.Pause();
    }

    //unpauses the music
    public void unpauseMusic()
    {
        backgroundAudio.UnPause();
    }

    //plays the menu click sound effect
    public void playMenuClick()
    {
        soundEffectsAudio[0].Play(0);
    }

    //plays the pause sound effect when the user pauses the game
    public void playMenuPauseSFX()
    {
        soundEffectsAudio[1].Play(0);
    }
}
