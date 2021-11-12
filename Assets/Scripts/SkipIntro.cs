using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipIntro : MonoBehaviour
{
    public void SkipIntroFunc()
    {
        GameObject.Find("OdysseyText").GetComponent<TextFade>().skipFade();
        GameObject.Find("IntroText").GetComponent<TextFade>().skipFade();
        GameObject.Find("IntroText (1)").GetComponent<TextFade>().skipFade();
        GameObject.Find("IntroText (2)").GetComponent<TextFade>().skipFade();
        GameObject.Find("StartButton").GetComponent<ImageFade>().skipFade();
        GameObject.Find("ButtonText").GetComponent<TextFade>().skipFade();
    }
}
