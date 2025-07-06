using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInteraction : MonoBehaviour
{
    //Made by Ben Zimmermann
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
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward * 0.3f);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactLayer.Contains(hit.collider.gameObject.layer))
               {
                if (interactable != null && interactable.IsInteractable())
                {
                    if (currentInteractable != interactable)
                    {
                        SetInteractable(interactable);
                    }
                    return;
                }
            }
        }

        ClearInteractable();
    }

    private void SetInteractable(Interactable interactable)
    {
        currentInteractable?.Remove();
        currentInteractable = interactable;
        currentInteractable.Apply();
        interactionText.text = currentInteractable.GetInteractionText();
        uiPanel.SetActive(true);
    }

    private void ClearInteractable()
    {
        currentInteractable?.Remove();
        currentInteractable = null;
        uiPanel.SetActive(false);
    }

    private void onInteract(CallbackContext ctx)
    {
        if (currentInteractable == null) return;

        currentInteractable.Interact();
        currentInteractable.Remove(); // Entfernt Highlight
        currentInteractable = null;
        uiPanel.SetActive(false);     // Versteckt UI
    }
}

public static class UnityExtensions
{

    /// <summary>
    /// Extension method to check if a layer is in a layermask
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public static bool Contains(this LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}