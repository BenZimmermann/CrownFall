using UnityEngine;

//[RequireComponent(typeof(Collider))]
public interface Interactable
{
   // public bool enabled;
    //public string interactionText = "Press E";
    //public Material highlightMaterial;
    //private Material[] originalMaterials;
    // private Renderer objectRenderer;

    public abstract void Awake();
    //{
    //    objectRenderer = GetComponent<Renderer>();
    //    originalMaterials = objectRenderer.materials;
    //}
    public abstract void Interact();
    //{
    //    Debug.Log("Interacted with: " + gameObject.name);
    //}
public abstract void Apply();
    //{
    //    {
    //        if (highlightMaterial == null) return;

    //        Material[] newMats = new Material[originalMaterials.Length + 1];
    //        originalMaterials.CopyTo(newMats, 0);
    //        newMats[newMats.Length - 1] = highlightMaterial;

    //        objectRenderer.materials = newMats;
    //    }
    //}
    public abstract void Remove();
    //{
    //    if (objectRenderer.materials.Length == originalMaterials.Length + 1)
    //    {
    //        objectRenderer.materials = originalMaterials;
    //    }
    //}
    public abstract string GetInteractionText();
    public abstract bool IsInteractable();
}