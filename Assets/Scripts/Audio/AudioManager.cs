using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    //attempts to see if this run is the player's first time playing
    private static readonly string FirstPlay = "FirstPlay";
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
        backgroundAudio.Play(0);
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        //if this is player's first time playing, sets volume to default values and sets them in 'PlayerPrefs' variable
        if (firstPlayInt == 0)
        {
            masterFloat = 1.0f;
            backgroundFloat = 0.4f;
            soundEffectsFloat = 0.3f;

            masterSlider.value = masterFloat;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;


            PlayerPrefs.SetFloat(MasterPref, masterFloat);
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);


            PlayerPrefs.SetInt(FirstPlay, -1);
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

    public void playGunShotSFX()
    {
        soundEffectsAudio[0].Play(0);
    }

    //plays the menu click sound effect
    public void playMenuClick()
    {
        soundEffectsAudio[2].Play(0);
    }

    //plays the pause sound effect when the user pauses the game
    public void playPauseSFX()
    {
        soundEffectsAudio[3].Play(0);
    }

    //resumes door opening sound effect when door is opening
    public void resumeDoorSFX()
    {
        soundEffectsAudio[5].UnPause();
    }

    //pauses door opening sound effect
    public void pauseDoorSFX()
    {
        soundEffectsAudio[5].Pause();
    }

    //starts door opening sound effect
    public void playDoorSFX()
    {
        soundEffectsAudio[5].Play(0);
    }

    //voice of AI sphere when first ship repair part is stashed
    public void playFirstStashedVoice()
    {
        soundEffectsAudio[6].Play(0);
    }

    //voice of AI sphere when second ship repair part is stashed
    public void playSecondStashedVoice()
    {
        soundEffectsAudio[7].Play(0);
    }

    //voice of AI sphere when third ship repair part is stashed
    public void playThirdStashedVoice()
    {
        soundEffectsAudio[8].Play(0);
    }

    //voice of AI sphere when fourth ship repair part is stashed
    public void playFourthStashedVoice()
    {
        soundEffectsAudio[9].Play(0);
    }

    //pauses voice of AI sphere when user pauses the game
    public void pauseFirstStashedVoice()
    {
        soundEffectsAudio[6].Pause();
    }

    public void pauseSecondStashedVoice()
    {
        soundEffectsAudio[7].Pause();
    }

    public void pauseThirdStashedVoice()
    {
        soundEffectsAudio[8].Pause();
    }

    public void pauseFourthStashedVoice()
    {
        soundEffectsAudio[9].Pause();
    }

    //resumes voice of AI sphere when user unpauses the game
    public void unpauseFirstStashedVoice()
    {
        soundEffectsAudio[6].UnPause();
    }
    public void unpauseSecondStashedVoice()
    {
        soundEffectsAudio[7].UnPause();
    }
    public void unpauseThirdStashedVoice()
    {
        soundEffectsAudio[8].UnPause();
    }
    public void unpauseFourthStashedVoice()
    {
        soundEffectsAudio[9].UnPause();
    }

    //validates if the AI sphere is being interacted or not
    public bool firstStashedVoiceIsPlaying()
    {
        return soundEffectsAudio[6].isPlaying;
    }
    public bool secondStashedVoiceIsPlaying()
    {
        return soundEffectsAudio[7].isPlaying;
    }
    public bool thirdStashedVoiceIsPlaying()
    {
        return soundEffectsAudio[8].isPlaying;
    }
    public bool fourthStashedVoiceIsPlaying()
    {
        return soundEffectsAudio[9].isPlaying;
    }

    //sound effect of collecting ship repair parts
    public void partsCollectedSFX()
    {
        soundEffectsAudio[10].Play(0);
    }

    //sound effect of stashins the ship repair parts inside the spaceship
    public void partsStashedSFX()
    {
        soundEffectsAudio[11].Play(0);
    }

    //plays countdown sound effect when user's oxygen level drops to 60
    public void playCountdownSFX()
    {
        soundEffectsAudio[12].Play(0);
    }

    //pauses countdown sound effect of oxygen level
    public void pauseCountdownSFX()
    {
        soundEffectsAudio[12].Pause();
    }
    
    //resumes countdown sound effect of oxygen level
    public void unpauseCountdownSFX()
    {
        soundEffectsAudio[12].UnPause();
    }

    //plays sound effect when user picks up oxygen tanks
    public void playPickUpOxygenTanksSFX()
    {
        soundEffectsAudio[13].Play(0);
    }

    //plays sound effect when golem attacks player
    public void playGolemAttackSFX()
    {
        soundEffectsAudio[14].Play(0);
    }

    //plays sound effect when dark knight attacks player
    public void playDarkKnightAttackSFX()
    {
        soundEffectsAudio[15].Play(0);
    }

    //plays sound effect when dragon attacks player
    public void playDragonAttackSFX()
    {
        soundEffectsAudio[16].Play(0);
    }
}
