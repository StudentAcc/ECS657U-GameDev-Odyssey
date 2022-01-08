using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour {
    [SerializeField] CharacterController controller;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    float speed;
    bool sprinting = false;
    Vector2 movementInput;
    
    [SerializeField] float jumpHeight;
    bool jump;
    [SerializeField] float gravity; // Gravity is -9.81f
    Vector3 verticalVelocity = Vector3.zero;

    [SerializeField] LayerMask groundMask;
    bool isGrounded;
    [SerializeField] public float stamina;
    [SerializeField] float staminaRegenRate;
    [SerializeField] float staminaRegenWaitTime;
    public float staminaCode;
    float timerCode;
    float elapsed = 0f;


    private PlayerInput playerInput;

    private void Start(){
        speed = walkSpeed;
        staminaCode = stamina;
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update() {
        isGrounded = Physics.CheckSphere(transform.position - (new Vector3(0, transform.localScale.y, 0)), 1f, groundMask);

        if (isGrounded) {
            verticalVelocity.y = 0;
        }


        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 horizontalVelocity = new Vector3(input.x, 0, input.y);

        horizontalVelocity = (transform.right * movementInput.x + transform.forward * movementInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        if (playerInput.actions["Jump"].triggered && isGrounded) {
            verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            jump = false;
        }
        
        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);

        if (sprinting && (movementInput.x!=0 || movementInput.y!=0))
        {
            timerCode = staminaRegenWaitTime;
            speed = sprintSpeed;
            elapsed += Time.deltaTime;
            staminaCode -= Time.deltaTime;

            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;
                GameObject.Find("OxygenBackground").GetComponent<CountDown>().onSprintDecreaseOxygen();
            }

            if (staminaCode <= 0f)
            {
                speed = walkSpeed;
                SprintReleased();
            }

        }
        else
        {
            timerCode -= Time.deltaTime;
            if (timerCode <= 0f)
            {
                timerCode = 0f;
                staminaCode += Time.deltaTime * staminaRegenRate;
            }
            if (staminaCode >= stamina)
            {
                staminaCode = stamina;
                timerCode = staminaRegenWaitTime;
            }
            if (staminaCode <= 0)
            {
                staminaCode = 0;
            }
            speed = walkSpeed;
            elapsed = 0f;
        }
        
    }

    public void SprintStarted()
    {
        sprinting = true;
    }
    public void SprintReleased()
    {
        sprinting = false;
    }

    public void ReceiveInput(Vector2 _movementInput) {
        movementInput = _movementInput;
    }

    public void OnJumpPressed() {
        jump = true;
    }

}