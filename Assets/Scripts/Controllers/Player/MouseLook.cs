using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    [SerializeField] float sensitivityX = 10f;
    [SerializeField] float sensitivityY = 10f;
    float mouseX, mouseY;

    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
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
