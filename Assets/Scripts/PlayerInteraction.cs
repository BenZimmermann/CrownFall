using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TextMeshProUGUI interactionText;
    [SerializeField] private LayerMask interactLayer;

    private PlayerInput playerInput;
    private Interactable currentInteractable;

     void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.actions["Interact"].performed += onInteract;

        if (playerCamera == null)
            playerCamera = Camera.main;

        uiPanel.SetActive(false);
    }

    private void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayer))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null && interactable.enabled)
            {
                if (currentInteractable != interactable)
                {
                    SetInteractable(interactable);
                }
                return;
            }
        }

        ClearInteractable();
    }

    private void SetInteractable(Interactable interactable)
    {
        currentInteractable = interactable;
        interactionText.text = currentInteractable.interactionText;
        uiPanel.SetActive(true);
    }

    private void ClearInteractable()
    {
        currentInteractable = null;
        uiPanel.SetActive(false);
    }

    private void onInteract(CallbackContext ctx)
    {
        Debug.Log("E gedrückt!");
        currentInteractable?.Interact();
    }
}
