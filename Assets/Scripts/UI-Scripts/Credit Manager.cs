using UnityEngine;
using UnityEngine.UI;
public class CreditManager : MonoBehaviour
{
    public static CreditManager Instance;



    public float scrollSpeed = 60f;
    public float startPositionY = -600f; // Starting position Y for the credits
    [SerializeField] private RectTransform creditText;
    [SerializeField] private RectTransform creditText2;

    [SerializeField] private bool isScrolling = true;

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
    void Start()
    {
        ResetCredits();
    }
    void Update()
    {
        if(!isScrolling) return;
        creditText.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        creditText2.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
    }
    public void ResetCredits()
    {
        creditText.anchoredPosition = new Vector2(0, startPositionY);
        creditText2.anchoredPosition = new Vector2(0, startPositionY);
        isScrolling = true;
    }

    public void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
