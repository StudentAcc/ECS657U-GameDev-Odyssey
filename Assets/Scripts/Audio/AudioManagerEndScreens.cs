using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerEndScreens : MonoBehaviour
{
    //initialises music and sfx audio sounds
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;

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
