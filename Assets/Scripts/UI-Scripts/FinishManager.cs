using UnityEngine;

public class FinishManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            TimeManager.Instance.StopTimer();
        }
    }
}
