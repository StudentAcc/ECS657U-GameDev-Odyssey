using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderValueToText : MonoBehaviour
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
        string sliderMessage = "Ship repair: " + GameObject.Find("Detector").GetComponent<ObjectiveSensor>().partsDetected + " / " + sliderUI.maxValue;
        sliderUI.value = GameObject.Find("Detector").GetComponent<ObjectiveSensor>().partsDetected;
        textSliderValue.text = sliderMessage;
    }

    public void ShowSliderValue()
    {
        string sliderMessage = "Ship repair: " + GameObject.Find("Detector").GetComponent<ObjectiveSensor>().partsDetected + " / " + sliderUI.maxValue;
        sliderUI.value = GameObject.Find("Detector").GetComponent<ObjectiveSensor>().partsDetected;
        textSliderValue.text = sliderMessage;
    }
}