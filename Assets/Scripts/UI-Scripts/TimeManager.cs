using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] private float DevTime = 18000f;
    float elapsedTime;
    private bool hasStarted = false;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void StartTimer()
    {
        if (!hasStarted)
        {
            hasStarted = true;
            elapsedTime = 0f; // Reset the timer when starting
        }
    }
    public void StopTimer()
    {
        hasStarted = false;
        CheckBestTime();
    }



    //private void OnTriggerEnter(Collider player)
    //{
    //    if(player.CompareTag("Player"))
    //    {
    //        hasStarted = true;
    //    }
    //}
    void Update()
    {
        if (!hasStarted) return;

        elapsedTime += Time.deltaTime;
        int Hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("Timer: {0:00}:{1:00}:{2:00}", Hours, minutes, seconds);
    }
    private void CheckBestTime()
    {
        if (elapsedTime <= DevTime)
        {
            Debug.Log("New Best Time: " + elapsedTime);
            OnBestTimeAchived(); // Update the best time
        }
        else
        {
            Debug.Log("Current Time: " + elapsedTime + " is not better than Best Time: " + DevTime);
        }
    }
    private void OnBestTimeAchived()
        {
        List<Slots> slots = EmblemUI.Instance.GetSlots(); //<- emblem returned transform.GetComponentsInCHildren<Slots>().ToList();
        Debug.Log($"SlotCount: {slots.Count}");
        foreach (Slots slot in slots)
        {
            if (slot.slotType == SlotType.Time)
            {
                slot.Achieve();

                return;
            }
        }

    }
}

