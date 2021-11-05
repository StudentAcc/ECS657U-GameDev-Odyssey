using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour {

    private Rigidbody sphereRigidbody;
    private PlayerInputActions playerInputActions;

    private void Awake() {
        sphereRigidbody = GetComponent<Rigidbody>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;

        // // Rebinding controls and saving them
        // playerInputActions.Player.Disable();
        // playerInputActions.Player.Jump.PerformInteractiveRebinding()
        //     .WithControlsExcluding("Mouse")
        //     .OnComplete(callback => {
        //         Debug.Log(callback.action.bindings[0].overridePath);
        //         callback.Dispose();
        //         playerInputActions.Player.Enable();
        //     })
        //     .Start();
    }

    // private void Update() {
    //     // Switch between action maps, for example when pause/resume is pressed to go from UI/game
    //     if (Keyboard.current.tKey.wasPressedThisFrame) {
    //         playerInput.SwitchCurrentActionMap("UI");
    //         playerInputActions.Player.Disable();
    //         playerInputActions.UI.Enable();
    //     }
    //     if (Keyboard.current.yKey.wasPressedThisFrame) {
    //         playerInput.SwitchCurrentActionMap("Player");
    //         playerInputActions.UI.Disable();
    //         playerInputActions.Player.Enable();
    //     }
    // }

    private void FixedUpdate() {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Debug.Log(inputVector);
        float speed = 5f;
        sphereRigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }

    public void Jump(InputAction.CallbackContext context) {
        Debug.Log(context);
        if (context.performed) {
            Debug.Log("Jump! " + context.phase);
            sphereRigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

}
