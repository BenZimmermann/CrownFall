using UnityEngine;
using TMPro;
public class ChestPopupManager : MonoBehaviour
{
    //Made by Ben Zimmermann
    [SerializeField] private GameObject popupWindow;
    [SerializeField] private TextMeshProUGUI popupText;

    public static ChestPopupManager Instance;

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
        popupWindow.SetActive(false);
    }
    public void ShowPopup(string message, float duration)
    {
        popupText.text = message;
        popupWindow.SetActive(true);
        CancelInvoke();
        Invoke(nameof(HidePopup), duration);
    }
    public void HidePopup()
    {
        popupWindow.SetActive(false);
    }
}
