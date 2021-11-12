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
    private IEnumerator coroutine;
    public Button primaryButton;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void skipFade()
    {
        StopCoroutine(coroutine);
        image.color = endColour;
        primaryButton.Select();
    }

    void Start ()
    {

        image.color = startColour;
        coroutine = imageFadeLerpIn();
        StartCoroutine(coroutine);
    }


    IEnumerator imageFadeLerpIn()
    {
        yield return new WaitForSeconds(fadeDelay);
        for (float t=0.01f; t<fadeInTime; t+=0.1f)
        {
            image.color = Color.Lerp(startColour, endColour, t / fadeInTime);
            yield return null;
        }
        primaryButton.Select();
    }
}