using UnityEngine;

public class AntiCheat : MonoBehaviour
{
    //dont change positions :( cheating is not cool!
    [SerializeField] private Vector3 startPosition = new Vector3(0, 0, 0);
    void Start()
    {
        transform.position = startPosition;
    }

}
