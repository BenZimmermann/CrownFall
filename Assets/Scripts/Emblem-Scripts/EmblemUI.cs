using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EmblemUI : MonoBehaviour
{
    //Made by Ben Zimmermann
    public static EmblemUI Instance;
    
    public void Initialize()
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Slots> GetSlots()
    {
       return transform.GetComponentsInChildren<Slots>().ToList();
    }   
}
