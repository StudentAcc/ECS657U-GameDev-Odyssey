using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerEndScreens : MonoBehaviour
{
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void playMenuClick()
    {
        soundEffectsAudio[0].Play(0);
    }

    public void playMenuPauseSFX()
    {
        soundEffectsAudio[1].Play(0);
    }
}
