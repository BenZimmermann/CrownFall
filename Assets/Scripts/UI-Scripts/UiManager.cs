using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class UiManager : MonoBehaviour
{
    //Made by Ben Zimmermann
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject SettingsCanvas;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject dialogueBox2;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject InvCanvas;

    // Referenz zum Kamera-Kontrollskript (z.B. MouseLook, FirstPersonController, etc.)
    [SerializeField] private MonoBehaviour cameraController;

    private PlayerInput playerInput;
    private bool isPaused = false;
    private bool isInvOpen = false;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        // ESC-Input abonnieren
        playerInput.actions["Pause"].performed += onPause;
        playerInput.actions["Inventar"].performed += onInv;

        // Menü am Anfang verstecken
        if (pauseCanvas != null)
            pauseCanvas.SetActive(false);
        //if (InvCanvas != null)
        //    InvCanvas.SetActive(false);
        if (SettingsCanvas != null)
            SettingsCanvas.SetActive(false);
        // Cursor ausblenden und sperren
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //bool isInvOpen = false;
        bool isPaused = false;
        if (InvCanvas != null)
            InvCanvas.SetActive(false);
        isInvOpen = false;
        InvCanvas.gameObject.GetComponentInChildren<EmblemUI>().Initialize();
    }
    public void Initialize() {

    }
    private void onPause(CallbackContext ctx)
    {
        if (isInvOpen || SettingsCanvas.activeSelf || dialogueBox.activeSelf || dialogueBox2.activeSelf) return;// Verhindert, dass das Pausieren während des Inventar geöffnet ist, funktioniert nicht wenn Inventar offen ist
        {
            isPaused = !isPaused;

            if (pauseCanvas != null)
                pauseCanvas.SetActive(isPaused);

            // Spiel-Zustand und Kamera anpassen
            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    private void onInv(CallbackContext ctx)
    {
        if (isPaused || SettingsCanvas.activeSelf || dialogueBox.activeSelf || dialogueBox2.activeSelf) return;
        {
            Debug.Log("onInv aufgerufen");
            isInvOpen = !isInvOpen;

            if (InvCanvas != null)
                InvCanvas.SetActive(isInvOpen);

            // Spiel-Zustand und Kamera anpassen
            if (isInvOpen)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }

            Debug.Log("Inventar geöffnet: " + isInvOpen);
        }
    }

    private void PauseGame()
    {
        // Cursor freigeben
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Zeit pausieren
        Time.timeScale = 0f;

        // Kamera-Controller deaktivieren
        if (cameraController != null)
            cameraController.enabled = false;
       // Debug.Log("Spiel pausiert, Kamera-Controller deaktiviert und Cursor freigegeben.");
    }

    private void ResumeGame()
    {
        // Nur fortsetzen wenn weder Pause noch Inventar offen ist
        if (!isPaused && !isInvOpen)
        {
            // Cursor sperren
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Zeit fortsetzen
            Time.timeScale = 1f;

            // Kamera-Controller aktivieren
            if (cameraController != null)
                cameraController.enabled = true;
            

        }
    }
    public void ContinoueButtonPressed()
    {
        Debug.Log("CancelButtonPressed aufgerufen");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Zeit fortsetzen
        Time.timeScale = 1f;

        // Kamera-Controller aktivieren
        if (cameraController != null)
            cameraController.enabled = true;
        if (InvCanvas != null)
            pauseCanvas.SetActive(false);
            isPaused = false;
    }
    public void QuitButtonPressed()
    {
        Debug.Log("QuitButtonPressed aufgerufen");
        SceneManager.LoadScene("MainMenu");
    }
    public void DialogButtonPressed()
    {
        Debug.Log("DialogButtonPressed aufgerufen");
        if (dialogueBox != null || dialogueBox2)
        {
            dialogueBox2.SetActive(false);
            dialogueBox.SetActive(false);
            // Cursor freigeben
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Kamera-Controller deaktivieren
            if (cameraController != null)
                cameraController.enabled = true;
        }
        else
        {
            Debug.LogWarning("Dialogue box is not assigned!");
        }
        dialogueBox2.SetActive(false);
        dialogueBox.SetActive(false);
    }
    public void DialogueOpened()
    {
        Debug.Log("DialogPressed aufgerufen");
       // dialogueBox.SetActive(true);
        // Cursor freigeben
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        // Kamera-Controller deaktivieren
        if (cameraController != null)
            cameraController.enabled = false;
    }
        public void SettingsButtonPressed()
    {
        Debug.Log("SettingsButtonPressed aufgerufen");
        SettingsCanvas.SetActive(true);
        // Cursor freigeben
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Zeit pausieren
        Time.timeScale = 0f;

        // Kamera-Controller deaktivieren
        if (cameraController != null)
            cameraController.enabled = false;
        pauseCanvas.SetActive(false);
    }
    public void BackButtonPressed()
    {
        Debug.Log("BackButtonPressed aufgerufen");
        SettingsCanvas.SetActive(false);
        // Cursor freigeben
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Zeit pausieren
        Time.timeScale = 0f;

        // Kamera-Controller deaktivieren
        if (cameraController != null)
            cameraController.enabled = false;
        if (InvCanvas != null)
            pauseCanvas.SetActive(true);


    }
    //void OnDestroy()
    //{
    //    // Input-Events abmelden
    //    if (playerInput != null)
    //    {
    //        playerInput.actions["Pause"].performed -= onPause;
    //        playerInput.actions["Inventar"].performed -= onInv;
    //    }
    //}


}