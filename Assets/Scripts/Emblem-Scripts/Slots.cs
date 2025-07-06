using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    //Made by Ben Zimmermann
    private bool isCollected;
    public SlotType slotType;

    [SerializeField] private Image slotImage;
    [SerializeField] private Color collectedColor = Color.white;
    [SerializeField] private Color uncollectedColor = new Color(1f, 1f, 1f, 0.3f);
    public void Awake()
    {
        UpdateVisual();
        isCollected = false;
    }
    public void Achieve()
    {

        // Initialize the slot as not collected
        isCollected = true;
        UpdateVisual();
        Debug.Log("JAAA");
    }
    private void UpdateVisual()
    {
            slotImage.color = isCollected ? collectedColor : uncollectedColor;
    }
}

public enum SlotType
{
    Summit,
    Starter,
    Farmer,
    Warrior,
    Time,
    Wizard,
    Coin,
    Master,
    Dennis,
}
