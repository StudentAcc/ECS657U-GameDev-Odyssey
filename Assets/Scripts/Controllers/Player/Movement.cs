using UnityEngine;

public class Movement : MonoBehaviour {
    //initialises character controller and the character's walk and sprint speed
    [SerializeField] CharacterController controller;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;

    //initialises characters actual speed
    float speed;

    //determine if character is sprinting or not by holding on the sprint button
    bool sprinting = false;
    Vector2 movementInput;

    //initialises audio and all different sound effects when walking, sprinting and jumping
    public GameObject walkingSound;
    public AudioSource walkingSource;

    public GameObject sprintingSound;
    public AudioSource sprintingSource;

    public GameObject jumpStartSound;
    public AudioSource jumpStartSource;

    public GameObject jumpLandSound;
    public AudioSource jumpLandSource;
    public AudioManager Audio;

    //determine jump height of character, whether or not they should jump and whether previously they were touching the ground
    [SerializeField] float jumpHeight;
    bool jump;
    bool previouslyTouchingGround;
    [SerializeField] float gravity; // Gravity is -9.81f
    Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;

    //initialises stamina of character and its regeneration rate
    [SerializeField] public float stamina;
    [SerializeField] float staminaRegenRate;
    [SerializeField] float staminaRegenWaitTime;
    public float staminaCode;
    float timerCode;
    float elapsed = 0f;

    private void Start(){
        //character starts with walk speed 
        speed = walkSpeed;
        staminaCode = stamina;

        //instantiates all different type of sound effects for walking, sprinting and jumping
        walkingSource = gameObject.AddComponent<AudioSource>();
        walkingSource.clip = walkingSound.GetComponent<AudioSource>().clip;

        sprintingSource = gameObject.AddComponent<AudioSource>();
        sprintingSource.clip = sprintingSound.GetComponent<AudioSource>().clip;

        jumpStartSource = gameObject.AddComponent<AudioSource>();
        jumpStartSource.clip = jumpStartSound.GetComponent<AudioSource>().clip;

        jumpLandSource = gameObject.AddComponent<AudioSource>();
        jumpLandSource.clip = jumpLandSound.GetComponent<AudioSource>().clip;
    }

    private void Update() {
        //determines if the player is touching the floor or not
        isGrounded = Physics.CheckSphere(transform.position - (new Vector3(0, transform.localScale.y, 0)), 1f, groundMask);

        //if the player is touching the ground, make their relative vertical velocity 0
        if (isGrounded) {
            verticalVelocity.y = 0;
        }

        //moves the player in the x and z plane
        Vector3 horizontalVelocity = (transform.right * movementInput.x + transform.forward * movementInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        //if the player is walking or sprinting, play the sound effects respective to whether they're walking or sprinting
        if (controller.isGrounded == true)
        {
            if (controller.velocity.magnitude < 14f && walkingSource.isPlaying == false)
            {
                playWalkingSound();
            }
            if (controller.velocity.magnitude > 14f && controller.velocity.magnitude < 21f && sprintingSource.isPlaying == false)
            {
                playSprintingSound();
            }
        }


        //when the player lands on the ground, play the jump landing sound effect
        if (isGrounded && previouslyTouchingGround == false)
        {
            playJumpLandSound();
            previouslyTouchingGround = true;
        }

        //if the player is on the ground and the user asks to jump, play the jumping sound effect and make the player jump
        if (jump) {
            if (isGrounded) 
            {
                playJumpStartSound();
                previouslyTouchingGround = false;
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }

        //gravity effect on player
        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);

        //if player is holding onto sprint button and actually moving (i.e. holding wasd), make player sprint and drain their stamina
        if (sprinting && (movementInput.x!=0 || movementInput.y!=0))
        {
            timerCode = staminaRegenWaitTime;
            //speed is now sprint speed so player is sprinting
            speed = sprintSpeed;
            elapsed += Time.deltaTime;
            staminaCode -= Time.deltaTime;

            //every second the player is sprinting, take one extra o2 level away
            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;
                GameObject.Find("OxygenBackground").GetComponent<CountDown>().onSprintDecreaseOxygen();
            }

            //if player has ran out of stamina, make player walk
            if (staminaCode <= 0f)
            {
                speed = walkSpeed;
                SprintReleased();
            }

        }
        else
        {
            //regenerates stamina if user isn't sprinting
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

    //plays walking sound effect
    public void playWalkingSound()
    {
        walkingSource.volume = Audio.GetComponent<AudioManager>().getSoundEffectsVolume();
        if (walkingSource.isPlaying)
        {
            walkingSource.Stop();
            walkingSource.Play();
        }
        else
        {
            walkingSource.Play();
        }
    }

    //plays sprinting sound effect
    public void playSprintingSound()
    {
        sprintingSource.volume = Audio.GetComponent<AudioManager>().getSoundEffectsVolume();
        if (sprintingSource.isPlaying)
        {
            sprintingSource.Stop();
            sprintingSource.Play();
        }
        else
        {
            sprintingSource.Play();
        }
    }

    //plays jump and then landing sound effect
    public void playJumpLandSound()
    {
        jumpLandSource.volume = Audio.GetComponent<AudioManager>().getSoundEffectsVolume();
        if (jumpLandSource.isPlaying)
        {
            jumpLandSource.Stop();
            jumpLandSource.Play();
        }
        else
        {
            jumpLandSource.Play();
        }
    }

    //plays jumping sound effect
    public void playJumpStartSound()
    {
        jumpStartSource.volume = Audio.GetComponent<AudioManager>().getSoundEffectsVolume();
        if (jumpStartSource.isPlaying)
        {
            jumpStartSource.Stop();
            jumpStartSource.Play();
        }
        else
        {
            jumpStartSource.Play();
        }
    }

    //sets sprinting to true
    public void SprintStarted()
    {
        sprinting = true;
    }

    //sets sprinting to false
    public void SprintReleased()
    {
        sprinting = false;
    }

    //receives player's movement input
    public void ReceiveInput(Vector2 _movementInput) {
        movementInput = _movementInput;
    }

    //sets jump to true if player has pressed jump button
    public void OnJumpPressed() {
        jump = true;
    }

}