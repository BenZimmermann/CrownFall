using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f; // Distance within which the player can interact with objects
    Interactable currentInteractable; // Reference to the currently interactable object
    private PlayerInput playerInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.actions["Interact"].performed += OnInteract;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteractable();
    }

    private void OnInteract(CallbackContext ctx)
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void CheckInteractable()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.tag == "Interactable")
            {
                Debug.Log("Interactable object detected: " + hit.collider.name);

                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (newInteractable != null && newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else
                {
                    DisableCurrentInteractable();
                }
            }
            else
            {
                DisableCurrentInteractable();
            }
        }
        else
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        Debug.Log("Setting new interactable: " + newInteractable.name);
        currentInteractable = newInteractable;
       // currentInteractable.EnableOutline();
    }

    void DisableCurrentInteractable()
    {
        if (currentInteractable != null)
        {
            Debug.Log("No interactable object in range, disabling current interactable: " + currentInteractable.name);  
            //  currentInteractable.DisableOutline();
         currentInteractable.enabled = false;
            currentInteractable = null;
        }
    }
}