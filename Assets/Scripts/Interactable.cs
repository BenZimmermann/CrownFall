using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Interactable : MonoBehaviour
{
  //  Outline outline;
    public string message;
    public UnityEvent onInteraction;

    public void Interact()
    {
        onInteraction.Invoke();
    }
}
