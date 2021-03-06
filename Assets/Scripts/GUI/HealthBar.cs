using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Slider bar for health
    public Slider sliderUI;

    private Text textSliderValue;

    void Start()
    {
        textSliderValue = GetComponent<Text>();
        sliderUI.maxValue = GameObject.Find("Player").GetComponent<CharacterStats>().maxHealth;
    }

    void Update()
    {
        string sliderMessage = "Health: " + GameObject.Find("Player").GetComponent<CharacterStats>().currentHealth;
        sliderUI.value = GameObject.Find("Player").GetComponent<CharacterStats>().currentHealth;
        textSliderValue.text = sliderMessage;
    }
}