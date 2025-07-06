using UnityEngine;

public class FinishManager : MonoBehaviour
{
    //Made by Ben Zimmermann
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            TimeManager.Instance.StopTimer();
        }
    }
}
