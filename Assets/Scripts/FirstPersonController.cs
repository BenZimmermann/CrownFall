using System.Runtime.CompilerServices;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [Header("Movement Speed")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float sprintMultiplier = 1.6f;

    [Header("Jump Parameters")]
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float gravityMultiplier = 9.81f;

    [Header("Coyote Time Parameters")]
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float jumpBufferTime = 0.2f;

    [Header("Look Parameters")]
    [SerializeField] private float mouseSensitivity = 0.125f;
    [SerializeField] private float upDownLookRange = 85.0f;

    [Header("References")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private PlayerInputHandler playerInputHandler;

    private Vector3 currentMovement;
    private float verticalRotation;
    private float airSpeed;
    private float coyoteTimer;
    private float jumpBufferTimer;
    private bool wasGrounded;

    private float CurrentSpeed => GetMovementSpeed();

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleCoyoteTime();
        HandleJumpBuffer();
        HandleMovement();
        HandleRotation();
    }

    private void HandleCoyoteTime()
    {
        bool isGrounded = characterController.isGrounded;

        // Start coyote timer when leaving ground (not from jumping)
        if (wasGrounded && !isGrounded && currentMovement.y <= 0)
        {
            coyoteTimer = coyoteTime;
        }

        // Reset timer when grounded
        if (isGrounded)
        {
            coyoteTimer = 0f;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
        }

        wasGrounded = isGrounded;
    }

    private void HandleJumpBuffer()
    {
        // Start jump buffer when jump input is pressed
        if (playerInputHandler.JumpPressed)
        {
            jumpBufferTimer = jumpBufferTime;
        }
        else
        {
            jumpBufferTimer -= Time.deltaTime;
        }
    }

    // Can jump if grounded OR within coyote time
    private bool CanJump()
    {
        return characterController.isGrounded || coyoteTimer > 0f;
    }

    // Has valid jump input (current press OR buffered)
    private bool HasJumpInput()
    {
        return playerInputHandler.JumpPressed;
    }

    private float GetMovementSpeed()
    {
        if (characterController.isGrounded)
        {
            return walkSpeed * (playerInputHandler.SprintPressed ? sprintMultiplier : 1);
        }
        else
        {
            return airSpeed;
        }
    }

    private Vector3 CalculateWorldDirection()
    {
        Vector3 inputDirection = new Vector3(playerInputHandler.MovementInput.x, 0f, playerInputHandler.MovementInput.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        return worldDirection.normalized;
    }

    private void HandleJump()
    {
        if (characterController.isGrounded)
        {
            currentMovement.y = -0.5f;
        }

        // Jump if we can jump AND have jump input
        if (CanJump() && HasJumpInput())
        {
            // Store current speed for air movement
            airSpeed = walkSpeed * (playerInputHandler.SprintPressed ? sprintMultiplier : 1);
            currentMovement.y = jumpForce;

            // Reset timers after jumping
            coyoteTimer = 0f;
            jumpBufferTimer = 0f;
        }
        else if (!characterController.isGrounded)
        {
            // Apply gravity when not grounded
            currentMovement.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
    }

    private void HandleMovement()
    {
        Vector3 worldDirection = CalculateWorldDirection();
        float currentSpeed = GetMovementSpeed();
        currentMovement.x = worldDirection.x * currentSpeed;
        currentMovement.z = worldDirection.z * currentSpeed;

        HandleJump();
        characterController.Move(currentMovement * Time.deltaTime);
    }

    private void ApplyHorizontalRotation(float rotationAmount)
    {
        transform.Rotate(0, rotationAmount, 0);
    }

    private void ApplyVerticalRotation(float rotationAmount)
    {
        verticalRotation = Mathf.Clamp(verticalRotation - rotationAmount, -upDownLookRange, upDownLookRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    private void HandleRotation()
    {
        float mouseXRotation = playerInputHandler.RotationInput.x * mouseSensitivity;
        float mouseYRotation = playerInputHandler.RotationInput.y * mouseSensitivity;

        ApplyHorizontalRotation(mouseXRotation);
        ApplyVerticalRotation(mouseYRotation);
    }
}