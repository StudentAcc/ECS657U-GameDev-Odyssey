using UnityEngine;

public class SFXValueChange : MonoBehaviour
{

    // Reference to Audio Source component
    private AudioSource audioSrc;

    // Music volume variable that will be modified
    // by dragging slider knob
    private float SFXVolume = 0.605f;

    // Use this for initialization
    void Start()
    {

        // Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Setting volume option of Audio Source to be equal to musicVolume
        audioSrc.volume = SFXVolume;
    }

    // Method that is called by slider game object
    // This method takes vol value passed by slider
    // and sets it as musicValue
    public void SetVolume(float vol)
    {
        SFXVolume = vol;
    }

}