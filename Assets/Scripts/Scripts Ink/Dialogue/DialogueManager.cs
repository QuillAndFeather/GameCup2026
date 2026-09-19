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
    }

    public void WriteText(string message)
    {
        DisplayTextBox(); //Display the text box

        displayText.text = message; //Update the message
    }
}
