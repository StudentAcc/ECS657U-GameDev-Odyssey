using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour {

    //initialises user's mouse sensitivty
    public float sensitivityX;
    public float sensitivityY;
    float mouseX, mouseY;

    //initialises sensitivity slider in controls menu
    public Slider sensitivitySlider;

    //initialises playerCamnera, xClamp and xRotation to be used in effect with mouse rotation and speed
    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;

    //when script is loaded, cursor is locked 
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        //set mouse sensitivity to the slider's value in the controls menu
        sensitivityX = sensitivitySlider.value;
        sensitivityY = sensitivitySlider.value;
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

}
