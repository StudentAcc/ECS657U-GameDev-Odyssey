using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipIntro : MonoBehaviour
{
    public void SkipIntroFunc()
    {
        GameObject.Find("OdysseyText").GetComponent<TextFade>().skipFade();
        GameObject.Find("1stPara").GetComponent<TextFade>().skipFade();
        GameObject.Find("2ndPara").GetComponent<TextFade>().skipFade();
        GameObject.Find("3rdPara").GetComponent<TextFade>().skipFade();
        GameObject.Find("LastLine").GetComponent<TextFade>().skipFade();
        GameObject.Find("StartButton").GetComponent<ImageFade>().skipFade();
        GameObject.Find("ButtonText").GetComponent<TextFade>().skipFade();
    }
}
