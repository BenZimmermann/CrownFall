using UnityEngine;

public class JARAmbeintManager : MonoBehaviour
{
    [SerializeField] private AudioSource ambientSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !ambientSource.isPlaying)
        {
            ambientSource.loop = true;
            ambientSource.Play();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !ambientSource.isPlaying)
        {
            ambientSource.loop = true;
            ambientSource.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && ambientSource.isPlaying)
        {
            ambientSource.Stop();

        }
    }
}
