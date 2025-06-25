using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    public string interactionText = "Press E";

    public virtual void Interact()
    {
        Debug.Log("Interacted with: " + gameObject.name);
    }
}