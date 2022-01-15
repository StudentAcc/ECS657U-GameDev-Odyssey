using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipIntro : MonoBehaviour
{
    // Ability to skip intro
    public void SkipIntroFunc()
    {
        GameObject.Find("OdysseyText").GetComponent<TextFade>().skipFade();
        GameObject.Find("1stPara").GetComponent<TextFade>().skipFade();
        GameObject.Find("2ndPara").GetComponent<TextFade>().skipFade();
        GameObject.Find("3rdPara").GetComponent<TextFade>().skipFade();
        GameObject.Find("LastLine").GetComponent<TextFade>().skipFade();
        GameObject.Find("StartGameButton").GetComponent<ImageFade>().skipFade();
        GameObject.Find("Text").GetComponent<TextFade>().skipFade();
        GameObject.Find("Audio").GetComponent<AudioScriptReading>().stopNarration();
    }
}
