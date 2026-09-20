using UnityEngine;
using UnityEngine.SceneManagement;



public class TaskDoorTrigger : MonoBehaviour
{
    public TaskSO assignedTask; //What is the task assigned to this door?

    public bool bExitDoor; //Is this an exit door?

    public string roomToLoad; //What is the room that this door will lead into?


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
            GameManager.instance.LoadRoomByName(roomToLoad);
            return;
        }

        //Check if the task has already been completed, not allowing entry if so
        if (assignedTask.bComplete && !bExitDoor)
        {
            //Run the dialogue display
            Debug.Log("I already completed what I needed to do here.. I think");

            return;
        }
        else if(assignedTask.bComplete && bExitDoor) //Else if the task is complete and is the exit, load back to the specified room
        {
            GameManager.instance.LoadRoomByName(roomToLoad);            
        }

        if(bExitDoor && !assignedTask.bComplete)
        {
            //Dialogue, I am not done here yet...
            Debug.Log("Incomplete task, resume");

            return;
        }

        bool bActiveTask = TaskManager.instance.bContainsTask(assignedTask); //Check if this task is currently active to allow the player to proceed or not

        if (bActiveTask) //Case that it is currently active
        {
            GameManager.instance.LoadRoomByName(roomToLoad); //Load the room that is assigned to this task
            Debug.Log("The player can participate in this minigame");
        }
        else //Case that it currently is not active
        {
            //Display in the dialogue display that the player has nothing to do here
            Debug.Log("Task in here? Delulu much?");
        }
    }
}
