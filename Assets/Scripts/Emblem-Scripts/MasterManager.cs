using System.Collections.Generic;
using UnityEngine;

public class MasterManager : MonoBehaviour
{
    //public bool isStarter = false;
    //public bool isSummit = false;
    public bool isFarmer = false;
    //public bool isWarrior = false;
    public bool isTime = false;
    public bool allEmblemeCollected = false;
    public bool isCoin = false;
    public bool isDennis = false;
    public int EmblemCount = 0;

    public static MasterManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdateMasterEmblemCount()
    {
        if (EmblemCount == 4)
        {
            allEmblemeCollected = true;
            MasterEmblem();
        }
    }
    public void MasterEmblem()
    {
        if (!isFarmer)
            return;
        else if (!isTime)
            return;
        else if (!allEmblemeCollected)
            return;
        else if (!isCoin)
            return;
        else if (!isDennis)
            return;
        GetMasterEmblem();
    }
    private void GetMasterEmblem()
    {
        Debug.Log("Master Emblem Acquired!");

        List<Slots> slots = EmblemUI.Instance.GetSlots(); //<- emblem returned transform.GetComponentsInCHildren<Slots>().ToList();
        Debug.Log($"SlotCount: {slots.Count}");
        foreach (Slots slot in slots)
        {
            if (slot.slotType == SlotType.Master)
            {
                slot.Achieve();

                return;
            }
        }
    }
    public void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}