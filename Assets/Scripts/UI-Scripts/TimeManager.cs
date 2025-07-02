using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    private bool hasStarted = false;
    private void OnTriggerEnter(Collider player)
    {
        if(player.CompareTag("Player"))
        {
            hasStarted = true;
        }
    }
    void Update()
    {
        if (!hasStarted) return;

        elapsedTime += Time.deltaTime;
        int Hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("Timer: {0:00}:{1:00}:{2:00}", Hours, minutes, seconds);
    }
}
