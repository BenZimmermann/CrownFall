using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FieldsManager : MonoBehaviour
{
    //Made by Ben Zimmermann
    [SerializeField] private GameObject FieldHeadline;
    [SerializeField] private TextMeshProUGUI FieldText;
    private CollectClass collectClass;
    void Start()
    {
        if (FieldHeadline != null)
        {
            FieldHeadline.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            FieldHeadline.SetActive(true);
            Debug.Log("Player entered the field area.");
        }
    }
    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            FieldHeadline.SetActive(false);
            Debug.Log("Player exited the field area.");
        }
    }
    private void Update()
    {
     FieldText.text = "Collect every Carrot(" + CarrotManager.Instance.carrotCounter + "/18)";
        if (CarrotManager.Instance.carrotCounter == 18)
        {
            GameEnd();

        }
    }
    private void GameEnd() {
        if (CarrotManager.Instance.carrotCounter >= 18)
        {
            FieldText.text = ("All Carrots Collected!");
            //AudioManager.Instance.PlaySFX(AudioManager.Instance.MinigameFinish);
            MasterManager.Instance.isFarmer = true;
            MasterManager.Instance.MasterEmblem();
        }
    }
}

