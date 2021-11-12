using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipRepair : MonoBehaviour
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
        string sliderMessage = "Spaceship Repairs: " + GameObject.Find("Detector").GetComponent<ObjectiveSensor>().partsDetected + " / " + sliderUI.maxValue;
        sliderUI.value = GameObject.Find("Detector").GetComponent<ObjectiveSensor>().partsDetected;
        textSliderValue.text = sliderMessage;
    }

    public void ShowSliderValue()
    {
        string sliderMessage = "Spaceship Repairs: " + GameObject.Find("Detector").GetComponent<ObjectiveSensor>().partsDetected + " / " + sliderUI.maxValue;
        sliderUI.value = GameObject.Find("Detector").GetComponent<ObjectiveSensor>().partsDetected;
        textSliderValue.text = sliderMessage;
    }
}