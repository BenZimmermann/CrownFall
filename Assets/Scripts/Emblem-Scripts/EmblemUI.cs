using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EmblemUI : MonoBehaviour
{
    public static EmblemUI Instance;
    
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.parent.gameObject.SetActive(false); // Deactivate the parent of this object
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Slots> GetSlots()
    {
       return transform.GetComponentsInChildren<Slots>().ToList();
    }   
}
