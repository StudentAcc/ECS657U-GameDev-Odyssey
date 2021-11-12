using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageFade : MonoBehaviour
{
    public Color startColour;
    public Color endColour;

    public float fadeInTime = 1f;
    public float fadeDelay = 3f;
    public Image image;
    PlayerInputActions controls;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnShootPressed()
    {
        image.color = endColour;
    }

    void Start ()
    {
        image.color = startColour;
        StartCoroutine(imageFadeLerpIn());
    }


    IEnumerator imageFadeLerpIn()
    {
        yield return new WaitForSeconds(fadeDelay);
        for (float t=0.01f; t<fadeInTime; t+=0.1f)
        {
            image.color = Color.Lerp(startColour, endColour, t / fadeInTime);
            yield return null;
        }
    }
}