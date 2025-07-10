using UnityEngine;

public class ChestManager : MonoBehaviour
{
    //Made by Ben Zimmermann
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
        ChestPopupManager.Instance.ShowPopup("Chest opened! Total: " + chestCounter + "/11", 2f);
        EndGame();
    }
    private void EndGame()
    {
        if (chestCounter >= 11)
        {
            ChestPopupManager.Instance.ShowPopup("All Coins Returned!", 3f);
            //AudioManager.Instance.PlaySFX(AudioManager.Instance.MinigameFinish);
            MasterManager.Instance.isCoin = true;
            MasterManager.Instance.MasterEmblem();
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
