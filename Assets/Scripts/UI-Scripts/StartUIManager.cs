using UnityEngine;
using UnityEngine.SceneManagement;
public class StartUIManager : MonoBehaviour
{
    [SerializeField] private AudioSource CreditMusic;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject SettingsCanvas;
    [SerializeField] private GameObject CreditsCanvas;

    private void Start()
    {
        if (SettingsCanvas != null)
            SettingsCanvas.SetActive(false);
        if (CreditsCanvas != null)
            CreditsCanvas.SetActive(false);
        if(MainMenu != null)
            MainMenu.SetActive(true);
    }
    public void OnStartPressed()
    {
        //load MainGame Scene
        SceneManager.LoadScene("MainGame");

    }
    public void OnSettingsPressed()
    {
        if (SettingsCanvas != null)
        {
            SettingsCanvas.SetActive(!SettingsCanvas.activeSelf);
            MainMenu.SetActive(!MainMenu.activeSelf);
        }
    }
    public void OnCreditsPressed()
    {
        CreditManager.Instance.ResetCredits();
        if (CreditsCanvas != null)
        {
            CreditsCanvas.SetActive(!CreditsCanvas.activeSelf);
            MainMenu.SetActive(!MainMenu.activeSelf);
        }
        if (CreditMusic != null)
        {
            CreditMusic.Play();
        }
    }
    public void OnExitPressed()
    {
        Debug.Log("Exit Game Pressed");
        Application.Quit();
    }
    public void OnbackPressed()
    {
        if (SettingsCanvas != null && SettingsCanvas.activeSelf)
        {
            SettingsCanvas.SetActive(false);
        }
        if (CreditsCanvas != null && CreditsCanvas.activeSelf)
        {
            CreditsCanvas.SetActive(false);
        }
        if (CreditMusic != null)
        {
            CreditMusic.Stop();
        }
        MainMenu.SetActive(true);
        CreditManager.Instance.ResetCredits();
    }
    public void OnGithubPressed()
    {
        Application.OpenURL("https://github.com/BenZimmermann");
    }
}
