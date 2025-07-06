using UnityEngine;

public class StartManager : MonoBehaviour
{
    //Made by Ben Zimmermann
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            TimeManager.Instance.StartTimer();
        }
    }
}
