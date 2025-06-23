using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PauseMenuToggle : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject InvCanvas;// Menü-Canvas
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

        // Cursor & Zeitsteuerung anpassen
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f; // Spiel pausieren
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f; // Spiel fortsetzen
        }
    }
    private void onInv(CallbackContext ctx)
    {
        Debug.Log("onInv aufgerufen"); // NEU
        isInvOpen = !isInvOpen;
        if (InvCanvas != null)
            InvCanvas.SetActive(isInvOpen);
        
        if (isInvOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f; // Spiel pausieren
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f; // Spiel fortsetzen
        }
    
    Debug.Log("Inventar geöffnet");
    }
}
