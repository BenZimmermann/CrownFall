using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] public AudioSource sfxSource;

    [Header("Sounds")]
    public AudioClip CoinCollect;
    public AudioClip NPCTalk;
    public AudioClip DoorOpen;
    public AudioClip MinigameFinish;
    public AudioClip ChestCollect;
    public AudioClip CarrotCollect;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if(clip != null)
            sfxSource.PlayOneShot(clip);
    }
    public void PlayCoinCollect() => PlaySFX(CoinCollect);
    public void PlayNPCTalk() => PlaySFX(NPCTalk);
    public void PlayDoorOpen() => PlaySFX(DoorOpen);
    public void PlayMinigameFinish() => PlaySFX(MinigameFinish);
    public void PlayChestCollect() => PlaySFX(ChestCollect);
    public void PlayCarrotCollect() => PlaySFX(CarrotCollect);

    private void Destroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
