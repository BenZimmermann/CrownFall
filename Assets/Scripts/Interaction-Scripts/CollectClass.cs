using UnityEngine;

public class CollectClass : MonoBehaviour, Interactable
{
    public bool isInteractable;
    public bool isEnabled = true;
    private bool used = false;
    public string interactionText = "(E) Collect";
    //public int CarrotCounter { get; private set; } = 0;
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
        CarrotManager.Instance.AddCarrot();
        if (used) return;
        if (!isEnabled) return;
        isEnabled = false;
        used = true; // Assuming 'used' is a field in this class to track interaction state
        Debug.Log("Interacted with: Carrot");
        Destroy(gameObject);
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
