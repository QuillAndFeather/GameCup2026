using UnityEngine;

public class TDoorTrigger : MonoBehaviour
{
    public TaskSO assignedTask; //What is the task assigned to this door?

    public bool bExitDoor; //Is this an exit door?

    public string roomToLoad; //What is the room that this door will lead into?

    [SerializeField] DialogueLinesSO taskAlreadyComplete; //Lines to run when the task is already done
    [SerializeField] DialogueLinesSO forgettingTask; //You got things to do y'know
    [SerializeField] DialogueLinesSO nonActiveTask; //Was that task always there?

    [SerializeField] AudioPlayer audioPlayer; //Reference to the Audio Player


    private void Start()
    {
        //audioPlayer = GetComponentInChildren<AudioPlayer>(); //Grab the child prefab
    }

    // Assigning the initial task

    public void AssignTask(TaskSO taskToAssign)
    {
        assignedTask = taskToAssign;
    }


    // Door trigger functionality

    public void DoorInteraction()
    {
        

        //Check if this is a brain room
        if (assignedTask is null && bExitDoor)
        {
            if(audioPlayer is not null) audioPlayer.PlayRandomSound(); //Play the door sound

            GameManager.instance.LoadRoomByName(roomToLoad);

            HideTaskList(); //Hide the task list
            return;
        }

        //Check if the task has already been completed, not allowing entry if so
        if (assignedTask.bComplete && !bExitDoor)
        {
            //Run the dialogue display
            Debug.Log("I already completed what I needed to do here.. I think");
            DialogueManager.instance.WriteText(DialogueManager.instance.GetRandomLine(taskAlreadyComplete)); //Run an already complete line

            return;
        }
        else if (assignedTask.bComplete && bExitDoor) //Else if the task is complete and is the exit, load back to the specified room
        {
            audioPlayer.PlayRandomSound(); //Play the door sound

            GameManager.instance.LoadRoomByName(roomToLoad);

            DisplayTaskList(); //Ensure the list is showing
        }

        if (bExitDoor && !assignedTask.bComplete)
        {
            //Dialogue, I am not done here yet...
            Debug.Log("Incomplete task, resume");
            DialogueManager.instance.WriteText(DialogueManager.instance.GetRandomLine(forgettingTask)); //You forgot the task when the lists right there?

            return;
        }

        bool bActiveTask = TskMaster.instance.bContainsTask(assignedTask); //Check if this task is currently active to allow the player to proceed or not

        if (bActiveTask) //Case that it is currently active
        {
            audioPlayer.PlayRandomSound(); //Play the door sound

            GameManager.instance.LoadRoomByName(roomToLoad); //Load the room that is assigned to this task
            Debug.Log("The player can participate in this minigame");

            HideTaskList(); //Hide the task list
        }
        else //Case that it currently is not active
        {
            //Display in the dialogue display that the player has nothing to do here
            Debug.Log("Task in here? Delulu much?");
            DialogueManager.instance.WriteText(DialogueManager.instance.GetRandomLine(nonActiveTask)); //Run an inactive task line
        }
    }


    // Enabling and Disabling the task list

    public void DisplayTaskList()
    {
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

    public void HideTaskList()
    {
        if (TaskManager.instance is not null)
        {
            TaskManager.instance.DisableTaskList();
        }

        if (TskMaster.instance is not null)
        {
            TskMaster.instance.DisableTaskList();
        }
    }
}
