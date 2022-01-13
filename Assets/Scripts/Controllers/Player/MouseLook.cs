using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour {

    public float sensitivityX;
    public float sensitivityY;
    float mouseX, mouseY;

    public Slider sensitivitySlider;

    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        sensitivityX = sensitivitySlider.value;
        sensitivityY = sensitivitySlider.value;
        transform.Rotate(Vector3.up, mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);

        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }

    public void ReceiveInput(Vector2 mouseInput) {
        mouseX = mouseInput.x * sensitivityX * Time.deltaTime;
        mouseY = mouseInput.y * sensitivityY * Time.deltaTime;
    }

}
