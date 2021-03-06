using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    // Slider bar for stamina
    public Slider sliderUI;

    void Start()
    { 
        sliderUI.maxValue = GameObject.Find("Player").GetComponent<Movement>().stamina;
    }

    void Update()
    {
        sliderUI.value = GameObject.Find("Player").GetComponent<Movement>().staminaCode;
    }
}