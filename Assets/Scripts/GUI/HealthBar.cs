using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider sliderUI;

    public float FillSpeed = 0.5f;
    private Text textSliderValue;

    void Start()
    {
        textSliderValue = GetComponent<Text>();
        ShowSliderValue();
    }

    void Update()
    {
        string sliderMessage = "Health: " + GameObject.Find("Player").GetComponent<CharacterStats>().currentHealth;
        sliderUI.value = GameObject.Find("Player").GetComponent<CharacterStats>().currentHealth;
        textSliderValue.text = sliderMessage;
    }

    public void ShowSliderValue()
    {
        string sliderMessage = "Health : " + GameObject.Find("Player").GetComponent<CharacterStats>().currentHealth;
        sliderUI.value = GameObject.Find("Player").GetComponent<CharacterStats>().currentHealth;
        textSliderValue.text = sliderMessage;
    }
}