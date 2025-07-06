using UnityEngine;
using System.Collections.Generic;

//erbt von Interactable, um Interaktionen zu ermöglichen
public class NPCClass : MonoBehaviour, Interactable
{
    //Made by Ben Zimmermann
    [SerializeField] private GameObject dialogueBox; // Assign this in the inspector
    public bool isInteractable;
    public bool isEnabled = true;
    private bool used = false;
    public string interactionText = "(E) Talk";
    public Material highlightMaterial;
    private Material[] originalMaterials;
    private Renderer objectRenderer;
    public UiManager UiManager;

    public void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterials = objectRenderer.materials;
    }
    public void Interact()
    {
        if (used) return;
        if (!isEnabled) return;
        used = true; // Assuming 'used' is a field in this class to track interaction state
        isEnabled = false;
        Debug.Log("Interacted with: Stone_Guy");
        Remove();
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true);
            UiManager.DialogueOpened();
            // You can also set the text of the dialogue box here if needed
            // dialogueBox.GetComponentInChildren<Text>().text = "Hello, I am the Stone Guy!";
        }
        else
        {
            Debug.LogWarning("Dialogue box is not assigned!");
        }
        //List<Slots> slots = Object.FindObjectsByType<Slots>(FindObjectsSortMode.None).ToList();
        List<Slots> slots = EmblemUI.Instance.GetSlots(); //<- emblem returned transform.GetComponentsInCHildren<Slots>().ToList();
            Debug.Log($"SlotCount: {slots.Count}");
            foreach (Slots slot in slots)
            {
                if (slot.slotType == SlotType.Dennis)
                {
                    slot.Achieve();

                    return;
                }
        }
        // Show the dialogue box
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
