using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColourLerper : MonoBehaviour
{
    public Color startColour;
    public Color endColour;

    public float fadeInTime = 1f;
    public float fadeOutTime = 2f;
    public float fadeDelay = 3f;

    public Renderer renderer;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    void Start ()
    {
        
    }

    public void ColourChangeActivate()
    {
        StartCoroutine(colourLerpIn());
    }

    IEnumerator colourLerpIn()
    {
        for (float t=0.01f; t<fadeInTime; t+=0.1f)
        {
            renderer.material.color = Color.Lerp(startColour, endColour, t / fadeInTime);
            yield return null;
        }
        StartCoroutine(colourLerpOut());
    }

    IEnumerator colourLerpOut()
    {
        for (float t = 0.01f; t < fadeOutTime; t += 0.1f)
        {
            renderer.material.color = Color.Lerp(endColour, startColour, t / fadeInTime);
            yield return null;
        }
    }
}