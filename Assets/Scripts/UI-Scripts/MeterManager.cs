using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeterManager : MonoBehaviour
{
    [Header("Ziel (z. B. Spieler)")]
    [SerializeField] private Transform target;

    [Header("UI (optional)")]
    [SerializeField] private TextMeshProUGUI meterText;

    private int lastCountedMeter = 0;

    private void Update()
    {
        if (target == null) return;

        float y = target.position.y;

        int evenY = Mathf.FloorToInt(y / 2f) * 2;

        // Jede 10er-Stufe zählt als 1 "Meter"
        int currentMeter = evenY / 2;

        // Nur aktualisieren, wenn Meter sich verändert
        if (currentMeter > lastCountedMeter)
        {
            lastCountedMeter = currentMeter;
            Debug.Log("Meter: " + currentMeter);

            if (meterText != null)
            {
                meterText.text = "Meter: " + currentMeter;
            }
        }
    }
}
