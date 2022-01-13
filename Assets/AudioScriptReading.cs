using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScriptReading : MonoBehaviour
{
    public AudioSource narration;


    // Start is called before the first frame update
    void Start()
    {
        narration.Play(0);
    }

    public void stopNarration()
    {
        narration.Stop();
    }

}
