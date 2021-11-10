using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;
    Vector2 movementInput;

    [SerializeField] float jumpHeight = 3.5f;
    bool jump;

    [SerializeField] float gravity = -30f; // Gravity is -9.81f
    Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;
    
    private void Update() {
        isGrounded = Physics.CheckSphere(transform.position - (new Vector3(0, transform.localScale.y, 0)), 1f, groundMask);
        if (isGrounded) {
            verticalVelocity.y = 0;
        }

        Vector3 horizontalVelocity = (transform.right * movementInput.x + transform.forward * movementInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        if (jump) {
            if (isGrounded) {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void ReceiveInput(Vector2 _movementInput) {
        movementInput = _movementInput;
    }

    public void OnJumpPressed() {
        jump = true;
    }

}
