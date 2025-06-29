using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public static ChestManager Instance;
    public int chestCounter { get; private set; }

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
    public void AddChest()
    {
        chestCounter++;
        ChestPopupManager.Instance.ShowPopup("Chest opened! Total: " + chestCounter + "/4", 2f);
        EndGame();
    }
    private void EndGame()
    {
        if (chestCounter >= 4)
        {
            ChestPopupManager.Instance.ShowPopup("All Coins Returned!", 3f);
        }

    }
}
