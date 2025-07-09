using UnityEngine;

public class CarrotManager : MonoBehaviour
{
    //Made by Ben Zimmermann
    public static CarrotManager Instance;
    public int carrotCounter { get; private set; }

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
    public void AddCarrot()
    {
        carrotCounter++;
        Debug.Log("Carrot collected! Total: " + carrotCounter);
    }
    public void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
