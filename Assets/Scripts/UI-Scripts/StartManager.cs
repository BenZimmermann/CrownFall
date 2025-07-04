using UnityEngine;

public class StartManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            TimeManager.Instance.StartTimer();
        }
    }
}
