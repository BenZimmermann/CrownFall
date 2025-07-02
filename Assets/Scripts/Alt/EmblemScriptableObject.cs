using UnityEngine;

[CreateAssetMenu(fileName = "NewEmblem", menuName = "Emblems/Emblem")]
public class EmblemScriptableObject : ScriptableObject
{
    public string displayName;
    public Sprite Icon;
    [TextArea] public string description;
}
