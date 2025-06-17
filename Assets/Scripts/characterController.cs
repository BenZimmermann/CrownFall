using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using static UnityEngine.InputSystem.InputAction;

public class characterController : MonoBehaviour
{
   private Vector2 playerInput;
   private Transform CamAction;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float sprintSpeed;
    private float currentSpeed;
    private bool isGrounded;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CamAction = Camera.main.transform;
        currentSpeed = speed;
        isGrounded = true; // Assuming the player starts on the ground
    }
    public void Movement(CallbackContext ctx)
    {
        playerInput = ctx.ReadValue<Vector2>();
    }
    public void Sprint(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log(currentSpeed);
            currentSpeed = sprintSpeed; // Set sprint speed when the action is performed
        }
        else if (ctx.canceled)
        {
            Debug.Log(currentSpeed);
            currentSpeed = speed; // Reset to default speed when the action is canceled
        }

    }
    public void Jump(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (isGrounded)
            {
                transform.Translate(Vector3.up * jumpForce * currentSpeed * Time.deltaTime, Space.World);
            }
        }
    }
    private void FixedUpdate()
    {
        var movementDirection = playerInput.x * CamAction.right + playerInput.y * Vector3.ProjectOnPlane(CamAction.forward, Vector3.up).normalized ;
        transform.Translate(currentSpeed * Time.deltaTime * movementDirection);
    }
}
