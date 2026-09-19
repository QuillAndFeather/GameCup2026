using UnityEngine;

public class TaskDoorTrigger : MonoBehaviour
{
    public TaskSO assignedTask; //What is the task assigned to this door?


    // Assigning the initial task

    public void AssignTask(TaskSO taskToAssign)
    {
        assignedTask = taskToAssign;
    }


    // Door trigger functionality

    public void DoorInteraction()
    {
        //Check if the task has already been completed, not allowing entry if so
        if (assignedTask.bComplete)
        {
            Debug.Log("I already completed what I needed to do here.. I think");

            return;
        }

        bool bActiveTask = TaskManager.instance.bContainsTask(assignedTask); //Check if this task is currently active to allow the player to proceed or not

        if (bActiveTask) //Case that it is currently active
        {
            Debug.Log("The player can participate in this minigame");
        }
        else //Case that it currently is not active
        {
            Debug.Log("Task in here? Delulu much?");
        }
    }
}
