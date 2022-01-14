using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    //initialises user's movement and mouse sensitivity
    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    
    //initialises 'Pickup' script
    [SerializeField] Pickup pickup;

    //initialises the user's weapon
    [SerializeField] GunController gun;
    [SerializeField] RayGun lasers;

    //initialises pause and inventory buttons
    [SerializeField] PauseMenuButtons pauseMenuButtons;
    [SerializeField] InventoryButtons inventoryButtons;

    //initialises user's controls and inputs
    PlayerInputActions controls;
    PlayerInputActions.PlayerActions playerActions;
    private PlayerInput playerInput;
    
    //initialises vectors for movement and mouse
    Vector2 movementInput;
    Vector2 mouseInput;

    private void Awake() {
        //defines the controls so that the player can move with their desired controls
        controls = new PlayerInputActions();
        playerActions = controls.Player;
        playerInput = GetComponent<PlayerInput>();

            // playerActions.Movement.started += context => movementInput = context.ReadValue<Vector2>();
            // playerActions.Movement.performed += context => movementInput = context.ReadValue<Vector2>();
            // playerActions.Movement.canceled += context => movementInput = context.ReadValue<Vector2>();

        //uses new input system to determine user's input controls whether they're using keyboard+mouse or controller
        playerInput.actions["Movement"].started += context => movementInput = context.ReadValue<Vector2>();
        playerInput.actions["Movement"].performed += context => movementInput = context.ReadValue<Vector2>();
        playerInput.actions["Movement"].canceled += context => movementInput = context.ReadValue<Vector2>();
        playerActions.Shoot.started += _ => gun.OnShootPressed();
        playerActions.Shoot.started += _ => lasers.OnShootPressed();
        playerInput.actions["Jump"].performed += _ => movement.OnJumpPressed();
        playerInput.actions["Pickup"].started += _ => pickup.OnPickupPressed();
        playerInput.actions["Pause"].performed += _ => pauseMenuButtons.PauseUnpause();
        playerInput.actions["Inventory"].performed += _ => inventoryButtons.OpenClose();
            // playerActions.Jump.performed += _ => movement.OnJumpPressed();
            // playerActions.Pickup.started += _ => pickup.OnPickupPressed();
            // playerActions.Pause.performed += _ => pauseMenuButtons.PauseUnpause();
            // playerActions.Inventory.performed += _ => inventoryButtons.OpenClose();

        playerActions.MouseX.started += context => mouseInput.x = context.ReadValue<float>();
        playerActions.MouseX.performed += context => mouseInput.x = context.ReadValue<float>();
        playerActions.MouseX.canceled += context => mouseInput.x = context.ReadValue<float>();

        playerActions.MouseY.started += context => mouseInput.y = context.ReadValue<float>();
        playerActions.MouseY.performed += context => mouseInput.y = context.ReadValue<float>();
        playerActions.MouseY.canceled += context => mouseInput.y = context.ReadValue<float>();
        
        playerInput.actions["Sprint"].started += _ => movement.SprintStarted();
        playerInput.actions["Sprint"].canceled += _ => movement.SprintReleased();
        // playerActions.Sprint.started += _ => movement.SprintStarted();
        // playerActions.Sprint.canceled += _ => movement.SprintReleased();
    }

    //checks user's control input per frame
    private void Update() {
        movement.ReceiveInput(movementInput);
        mouseLook.ReceiveInput(mouseInput);
    }

    //method that enables user's input actions
    private void OnEnable() {
        controls.Player.Enable();
    }

    //method that disables user's input actions
    private void OnDisable() {
        controls.Player.Disable();
    }

}
