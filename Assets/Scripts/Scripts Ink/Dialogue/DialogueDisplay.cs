using UnityEngine;

public class DialogueDisplay : MonoBehaviour
{
    /// <summary>
    /// This script is the main caller to the dialogue manager when it needs to be displayed
    /// </summary>

    [SerializeField] DialogueLinesSO dialogueLines; //List of lines to select from

    public void DisplayRandomMessage()
    {
        FindAnyObjectByType<PlayerController>().SwapMovementState(); //Make is so player cannot move

        int index = Random.Range(0, dialogueLines.lines.Length); //Select a random index line

        DialogueManager.instance.WriteText(dialogueLines.lines[index]);  //Play the selected line
    }
}
