using UnityEngine;

public class ChestClass : MonoBehaviour, Interactable
{
    public bool isInteractable;
    public bool isEnabled = true;
    private bool used = false;
    public string interactionText = "(E) Open";
    public Material highlightMaterial;
    private Material[] originalMaterials;
    private Renderer objectRenderer;

    public void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterials = objectRenderer.materials;
    }
    public void Interact()
    {
        ChestManager.Instance.AddChest(); // Assuming ChestManager is a singleton managing chest interactions
        if (!isEnabled) return;
        if (used) return;
        used = true; // Assuming 'used' is a field in this class to track interaction state
        isEnabled = false;
        Debug.Log("Interacted with: Chest");
        Remove();
    }
    public void Apply()
    {
        {
            if (used || highlightMaterial == null) return;

            Material[] newMats = new Material[originalMaterials.Length + 1];
            originalMaterials.CopyTo(newMats, 0);
            newMats[newMats.Length - 1] = highlightMaterial;

            objectRenderer.materials = newMats;
        }
    }

    public void Remove()
    {
        if (objectRenderer.materials.Length == originalMaterials.Length + 1)
        {
            objectRenderer.materials = originalMaterials;
        }
    }
    public string GetInteractionText()
    {
        return interactionText;
    }
    public bool IsInteractable()
    {
        return !used;
    }
}
