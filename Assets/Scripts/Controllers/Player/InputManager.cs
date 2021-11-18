using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    [SerializeField] Pickup pickup;
    [SerializeField] Gun gun;
    [SerializeField] PauseMenuButtons pauseMenuButtons;

    PlayerInputActions controls;
    PlayerInputActions.PlayerActions playerActions;
    
    Vector2 movementInput;
    Vector2 mouseInput;

    private void Awake() {
        controls = new PlayerInputActions();
        playerActions = controls.Player;

        playerActions.Movement.performed += context => movementInput = context.ReadValue<Vector2>();

        playerActions.Jump.performed += _ => movement.OnJumpPressed();
        playerActions.Pickup.started += _ => pickup.OnPickupPressed();
        playerActions.Shoot.started += _ => gun.OnShootPressed();
        playerActions.Pause.performed += _ => pauseMenuButtons.PauseUnpause();

        playerActions.MouseX.performed += context => mouseInput.x = context.ReadValue<float>();
        playerActions.MouseY.performed += context => mouseInput.y = context.ReadValue<float>();

        playerActions.Sprint.started += _ => movement.SprintStarted();
        playerActions.Sprint.canceled += _ => movement.SprintReleased();
    }

    private void Update() {
        movement.ReceiveInput(movementInput);
        mouseLook.ReceiveInput(mouseInput);
    }

    private void OnEnable() {
        controls.Player.Enable();
    }

    private void OnDisable() {
        controls.Player.Disable();
    }

}
