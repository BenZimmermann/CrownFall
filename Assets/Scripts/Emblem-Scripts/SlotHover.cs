using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //[SerializeField] public Image icon;
    [SerializeField] public GameObject tooltipPanel;
    //[SerializeField] public TextMeshProUGUI tooltipText;
    //private EmblemScriptableObject emblemData;

    //public void Initialize(EmblemScriptableObject data, bool isCollected)
    //{
    //    emblemData = data; 
    //    icon.sprite = data.Icon;
    //    icon.color = isCollected ? Color.white : new Color(1, 1, 1, 0.5f); // Dim the icon if not collected
    //}
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipPanel.SetActive(true);
       // tooltipText.text = emblemData.description;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipPanel.SetActive(false);

    }

}
