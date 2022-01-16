using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour {

    //initialises user's mouse sensitivty
    public float sensitivityX;
    public float sensitivityY;
    float mouseX, mouseY;

    //initialises variables to see if player if playing game for first time
    private static readonly string FirstPlayMouse = "FirstPlay";
    private int firstPlayInt;

    //initialises sensitivity slider in controls menu
    public Slider sensitivitySlider;

    //initialises playerCamnera, xClamp and xRotation to be used in effect with mouse rotation and speed
    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;

    void Start() 
    {
        //if this is player's first time playing, set default mouse sensitivity and remember it
        firstPlayInt = PlayerPrefs.GetInt(FirstPlayMouse);
        if (firstPlayInt == 0)
        {
            PlayerPrefs.SetFloat("Mouse Sensitivity", 2f);

            PlayerPrefs.SetInt(FirstPlayMouse, -1);
        }
        //otherwise, set the sensitivity to what the player previously set it as
        else
        {
            sensitivitySlider.value = PlayerPrefs.GetFloat("Mouse Sensitivity");
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        //set mouse sensitivity to the slider's value in the controls menu
        sensitivityX = PlayerPrefs.GetFloat("Mouse Sensitivity");
        sensitivityY = PlayerPrefs.GetFloat("Mouse Sensitivity");
        transform.Rotate(Vector3.up, mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);

        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }

    //defines mouse sensitivity based on the mouse input
    public void ReceiveInput(Vector2 mouseInput) {
        mouseX = mouseInput.x * sensitivityX * Time.deltaTime;
        mouseY = mouseInput.y * sensitivityY * Time.deltaTime;
    }

    //method that changes mouse sensitivity based on player's preferences
    public void changeMouseSensitivity()
    {
        PlayerPrefs.SetFloat("Mouse Sensitivity", sensitivitySlider.value);
    }

}
