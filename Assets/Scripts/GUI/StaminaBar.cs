using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider sliderUI;

    void Update()
    {
        sliderUI.value = GameObject.Find("Player").GetComponent<Movement>().staminaCode;
    }
}