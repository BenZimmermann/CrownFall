using UnityEngine;
using System.Collections.Generic;

public class Emblem : MonoBehaviour
{
    //Made by Ben Zimmermann
    [SerializeField] SlotType slotType;
    MasterManager MasterManager;
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            Debug.Log("Player entered the emblem trigger area.");
            // Get the EmblemUI instance and the list of slots
            var slots = EmblemUI.Instance.GetSlots();
            // Find the slot with the type Starter
            var aChievedSlot = slots.Find(slot => slot.slotType == slotType);

            // If the slot is found, achieve it
            if (aChievedSlot != null)
            {
                aChievedSlot.Achieve();
                Debug.Log("Starter slot achieved!");
                Destroy(gameObject);
                ++MasterManager.Instance.EmblemCount;
                MasterManager.Instance.UpdateMasterEmblemCount();
            }
            else
            {
                Debug.LogWarning("Starter slot not found!");
            }
        }
    }
}