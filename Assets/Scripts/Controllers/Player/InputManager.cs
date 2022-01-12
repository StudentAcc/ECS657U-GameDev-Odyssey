using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    [SerializeField] Pickup pickup;
    [SerializeField] GunController gun;
    [SerializeField] RayGun lasers;
    [SerializeField] PauseMenuButtons pauseMenuButtons;

    PlayerInputActions controls;
    PlayerInputActions.PlayerActions playerActions;
    private PlayerInput playerInput;
    
    Vector2 movementInput;
    Vector2 mouseInput;

    private void Awake() {
        controls = new PlayerInputActions();
        playerActions = controls.Player;
        playerInput = GetComponent<PlayerInput>();

        // playerActions.Movement.started += context => movementInput = context.ReadValue<Vector2>();
        // playerActions.Movement.performed += context => movementInput = context.ReadValue<Vector2>();
        // playerActions.Movement.canceled += context => movementInput = context.ReadValue<Vector2>();

        playerInput.actions["Movement"].started += context => movementInput = context.ReadValue<Vector2>();
        playerInput.actions["Movement"].performed += context => movementInput = context.ReadValue<Vector2>();
        playerInput.actions["Movement"].canceled += context => movementInput = context.ReadValue<Vector2>();

        playerActions.Shoot.started += _ => gun.OnShootPressed();
        playerActions.Shoot.started += _ => lasers.OnShootPressed();
        // playerActions.Jump.performed += _ => movement.OnJumpPressed();
        playerInput.actions["Jump"].performed += _ => movement.OnJumpPressed();
        // playerActions.Pickup.started += _ => pickup.OnPickupPressed();
        playerInput.actions["Pickup"].started += _ => pickup.OnPickupPressed();
        // playerActions.Pause.performed += _ => pauseMenuButtons.PauseUnpause();
        playerInput.actions["Pause"].performed += _ => pauseMenuButtons.PauseUnpause();

        playerActions.MouseX.started += context => mouseInput.x = context.ReadValue<float>();
        playerActions.MouseX.performed += context => mouseInput.x = context.ReadValue<float>();
        playerActions.MouseX.canceled += context => mouseInput.x = context.ReadValue<float>();

        playerActions.MouseY.started += context => mouseInput.y = context.ReadValue<float>();
        playerActions.MouseY.performed += context => mouseInput.y = context.ReadValue<float>();
        playerActions.MouseY.canceled += context => mouseInput.y = context.ReadValue<float>();
        
        // playerActions.Sprint.started += _ => movement.SprintStarted();
        playerInput.actions["Sprint"].started += _ => movement.SprintStarted();
        // playerActions.Sprint.canceled += _ => movement.SprintReleased();
        playerInput.actions["Sprint"].canceled += _ => movement.SprintReleased();

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
