using UnityEngine;

public class Slots : MonoBehaviour
{
    [SerializeField] SlotType slotType;
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
