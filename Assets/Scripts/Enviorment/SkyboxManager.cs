using UnityEngine;

public class SkyboxManager : MonoBehaviour
{

    [SerializeField] private Material newSkybox;
    [SerializeField] private Light sceneLight;

    [SerializeField] private Material originalSkyboxMaterial;
    [SerializeField] private AudioSource ambientSource;
    void Start()
    {
        ambientSource.playOnAwake = false;
        ambientSource.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !ambientSource.isPlaying)
        {
            ambientSource.loop = true;
            ambientSource.Play();

            if (newSkybox != null)
            {
                RenderSettings.skybox = newSkybox;
                DynamicGI.UpdateEnvironment();
            }

            if (sceneLight != null)
                sceneLight.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && ambientSource.isPlaying)
        {
            ambientSource.Stop();
            RenderSettings.skybox = originalSkyboxMaterial;
            DynamicGI.UpdateEnvironment();

            if (sceneLight != null)
                sceneLight.enabled = true;
        }
    }
}

