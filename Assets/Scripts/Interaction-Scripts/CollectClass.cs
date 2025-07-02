using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
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

        if(CarrotManager.Instance.carrotCounter >= 3)
        {
            //List<Slots> slots = Object.FindObjectsByType<Slots>(FindObjectsSortMode.None).ToList();
            List<Slots> slots = EmblemUI.Instance.GetSlots(); //<- emblem returned transform.GetComponentsInCHildren<Slots>().ToList();
            Debug.Log($"SlotCount: {slots.Count}");
            foreach (Slots slot in slots)
            {
                if(slot.slotType == SlotType.Farmer)
                {
                    slot.Achieve();

                    return;
                }
            }
        }
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
