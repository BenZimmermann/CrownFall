using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

// This class controls the player character in Unity
public class PlayerController : MonoBehaviour
{
    // Reference to the PlayerInput object (for input handling)
    private PlayerInput playerInput;
    // Reference to the Rigidbody object (for physics)
    private Rigidbody rb;
    // Stores the movement direction as a 2D vector (x = left/right, y = forward/backward)
    private Vector2 movementInput;
    // Reference to the camera to move relative to the camera
    private Transform cameraTransform;
    // Speed at which the player moves (can be set in the editor)
    [SerializeField] private float actualMovementSpeed;
    // Strength of the jump (can be set in the editor)
    [SerializeField] private float jumpStrength;
    // Indicates whether the player is touching the ground
    [SerializeField] private float sprintSpeed;
    private bool isGrounded;
    [SerializeField] private float currentSpeed;

    // Called once at the start of the game
    void Start()
    {
        // Get the components from the GameObject
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();

        // Link the input actions to the methods
        playerInput.actions["Move"].performed += onMove;
        playerInput.actions["Move"].canceled += onMove;
        playerInput.actions["Jump"].performed += onJump;
        playerInput.actions["Jump"].canceled += onJump;
        playerInput.actions["Sprint"].performed += onSprint;
        playerInput.actions["Sprint"].canceled += onSprint;

        // Get the transform component of the main camera
        cameraTransform = Camera.main.transform;
        currentSpeed = actualMovementSpeed;
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen
        Cursor.visible = false; // Hides the cursor
    }

    // Called when the movement input changes
    public void onMove(CallbackContext ctx)
    {
        // Reads the direction of movement (e.g. from WASD or joystick)
        movementInput = ctx.ReadValue<Vector2>();
    }


    // Called when the jump button is pressed
    public void onJump(CallbackContext ctx)
    {
        // Only jump if the player is on the ground

        if (!isGrounded) return;
        // Adds an upward force to jump
        rb.AddForce(Vector3.up * jumpStrength);
        Debug.Log("Jump");
    }
    public void onSprint(CallbackContext ctx)
    {

        // If the sprint action is performed, increase the movement speed
        if (ctx.performed)
        {
            currentSpeed = sprintSpeed;
        }
        // If the sprint action is canceled, reset to normal speed
        else if (ctx.canceled)
        {
            currentSpeed = actualMovementSpeed;
        }
    }

    // Called once per frame
    void FixedUpdate()
    {
        // Calculates the movement direction relative to the camera
        var movementDirection = cameraTransform.right * movementInput.x + cameraTransform.forward * movementInput.y;
        // Removes the vertical component so the player doesn't move up/down
        movementDirection = Vector3.ProjectOnPlane(movementDirection, Vector3.up).normalized;
        var targetPos = transform.position + movementDirection * Time.deltaTime * currentSpeed;
        // Moves the player in the desired direction
        rb.MovePosition(targetPos);
        // The following line is commented out and shows how 2D movement looked in our RPG
        //transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * actualMovementSpeed);
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 3f, Color.green);
    }

    // Called as long as the player is colliding with something (e.g. the ground)
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
        Debug.Log("Grounded: " + isGrounded);
    }

    // Called when the player stops colliding with something (e.g. the ground)
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}