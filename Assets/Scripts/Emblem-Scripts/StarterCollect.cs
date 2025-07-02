using UnityEngine;

public class StarterCollect : MonoBehaviour
{
    SlotType slotType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the EmblemUI instance and the list of slots
            var slots = EmblemUI.Instance.GetSlots();
            // Find the slot with the type Starter
            var starterSlot = slots.Find(slot => slot.slotType == slotType);

            // If the slot is found, achieve it
            if (starterSlot != null)
            {
                starterSlot.Achieve();
                Debug.Log("Starter slot achieved!");
            }
            else
            {
                Debug.LogWarning("Starter slot not found!");
            }
        }
    }
}
