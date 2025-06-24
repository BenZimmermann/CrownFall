using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PauseMenuToggle : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
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
        if (InvCanvas != null)
            InvCanvas.SetActive(false);

        // Cursor ausblenden und sperren
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void onPause(CallbackContext ctx)
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

    private void onInv(CallbackContext ctx)
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