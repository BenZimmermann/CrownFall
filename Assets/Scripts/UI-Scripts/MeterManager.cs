using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeterManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TextMeshProUGUI meterText;
    [SerializeField] private Transform ground;
    [SerializeField] private float meterHeight = 1f; // Höhe eines "Meters" in Unity-Einheiten

    private int lastMeter = -999;

    private void Update()
    {
        if (player == null || ground == null) return;

        float height = player.position.y - ground.position.y;
        float minHeight = Mathf.Max(0f, height); // Sicherstellen, dass die Höhe nicht negativ wird

        int current = Mathf.FloorToInt(minHeight / meterHeight);

        // Nur aktualisieren, wenn Meter sich verändert
        if (current != lastMeter)
        {
            lastMeter = current;
            Debug.Log("Meter: " + current);

            if (meterText != null)
            {
                meterText.text = "Meter: " + current;
            }
        }
    }
}
