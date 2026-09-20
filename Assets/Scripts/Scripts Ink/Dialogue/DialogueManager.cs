using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    [SerializeField] GameObject DialogueTextBox;

    [SerializeField] TMP_Text displayText; //Text for message to play


    private void Awake()
    {
        instance = this;
    }

    // Text displaying functions

    public void DisplayTextBox()
    {
        DialogueTextBox.SetActive(true);
    }

    public void DisableTextBox()
    {
        DialogueTextBox.SetActive(false);

        //Display the tasks if they are not already up
        if (TaskManager.instance is not null)
        {
            TaskManager.instance.EnableTaskList();
            TaskManager.instance.DisplayTasks();
        }

        if (TskMaster.instance is not null)
        {
            TskMaster.instance.EnableTaskList();
            TskMaster.instance.DisplayTasks();
        }
    }

    public void WriteText(string message)
    {
        DisplayTextBox(); //Display the text box

        GameManager.instance.controller.bCanMove = false; //Make is so the player cannot move

        displayText.text = message; //Update the message
    }

    public string GetRandomLine(DialogueLinesSO inputDialogueLines)
    {
        int index = Random.Range(0, inputDialogueLines.lines.Length); //Get a random line

        return inputDialogueLines.lines[index]; //Return the index line
    }
}
