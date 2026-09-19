using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Lines", menuName = "Dialogue Line Container")]
public class DialogueLinesSO : ScriptableObject
{
    public string[] lines; //Array of dialogue lines to select from
}
