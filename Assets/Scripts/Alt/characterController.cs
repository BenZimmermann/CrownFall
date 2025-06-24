//using UnityEngine;
//using System.Collections.Generic;
//using System.Collections;
//using static UnityEngine.InputSystem.InputAction;

//public class characterController : MonoBehaviour
//{
//   private Vector2 playerInput;
//   private Transform CamAction;
//    [SerializeField] private float speed;
//    [SerializeField] private float jumpForce;
//    [SerializeField] private float sprintSpeed;
//    private float currentSpeed;
//    private bool isGrounded;
//    private Rigidbody rb;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        Cursor.lockState = CursorLockMode.Locked;
//        Cursor.visible = false;
//        CamAction = Camera.main.transform;
//        currentSpeed = speed;
//        isGrounded = true;
//    }
//    public void Movement(CallbackContext ctx)
//    {
//        playerInput = ctx.ReadValue<Vector2>();
//    }
//    public void Sprint(CallbackContext ctx)
//    {
//        if (ctx.performed)
//        {
//            Debug.Log(currentSpeed);
//            currentSpeed = sprintSpeed;
//        }
//        else if (ctx.canceled)
//        {
//            Debug.Log(currentSpeed);
//            currentSpeed = speed;
//        }

//    }
//    public void onJump(CallbackContext ctx)
//    {
//        rb.AddForce(Vector3.up * jumpForce);
//        Debug.Log("Jumped: " + ctx.performed);
//    }
//    private void FixedUpdate()
//    {
//        var movementDirection = playerInput.x * CamAction.right + playerInput.y * Vector3.ProjectOnPlane(CamAction.forward, Vector3.up).normalized ;
//        transform.Translate(currentSpeed * Time.deltaTime * movementDirection);
//    }
//}
