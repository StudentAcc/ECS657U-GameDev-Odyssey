using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextFade : MonoBehaviour
{
    public Color startColour;
    public Color endColour;

    public float fadeInTime = 1f;
    public float fadeDelay = 3f;
    public Text text;
    private IEnumerator coroutine;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    public void skipFade()
    {
        StopCoroutine(coroutine);
        text.color = endColour;
    }

    void Start()
    {
        text.color = startColour;
        coroutine = textFadeLerpIn();
        StartCoroutine(coroutine);
    }


    IEnumerator textFadeLerpIn()
    {
        yield return new WaitForSeconds(fadeDelay);
        for (float t = 0.01f; t < fadeInTime; t += 0.1f)
        {
            text.color = Color.Lerp(startColour, endColour, t / fadeInTime);
            yield return null;
        }
    }
}