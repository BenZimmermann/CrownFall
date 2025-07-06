using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ChestClass : MonoBehaviour, Interactable
{
    //Made by Ben Zimmermann
    public bool isInteractable;
    public bool isEnabled = true;
    private bool used = false;
    public string interactionText = "(E) Open";
    public List<GameObject> outlineObjects;
    private Material[] originalMaterials;
    private Renderer objectRenderer;

    public void Awake()
    {
        SetOutline(false);
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

        if (ChestManager.Instance.chestCounter >= 11)
        {
            //List<Slots> slots = Object.FindObjectsByType<Slots>(FindObjectsSortMode.None).ToList();
            List<Slots> slots = EmblemUI.Instance.GetSlots(); //<- emblem returned transform.GetComponentsInCHildren<Slots>().ToList();
            Debug.Log($"SlotCount: {slots.Count}");
            foreach (Slots slot in slots)
            {
                if (slot.slotType == SlotType.Coin)
                {
                    slot.Achieve();

                    return;
                }
            }
        }
    }
    public void Apply()
    {
        SetOutline(true);
        {
            //if (used || highlightMaterial == null) return;

            //Material[] newMats = new Material[originalMaterials.Length + 1];
            //originalMaterials.CopyTo(newMats, 0);
            //newMats[newMats.Length - 1] = highlightMaterial;

            //objectRenderer.materials = newMats;
        }
    }

    public void Remove()
    {
        SetOutline(false);
        //if (objectRenderer.materials.Length == originalMaterials.Length + 1)
        //{
        //    objectRenderer.materials = originalMaterials;
        //}
    }

    private void SetOutline(bool isOutlineOn)
    {
        foreach (GameObject obj in outlineObjects)
        {
            obj.SetActive(isOutlineOn);
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
