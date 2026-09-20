using System;
using UnityEngine;

public abstract class RoomConditionManager : MonoBehaviour
{

    public bool[] bChecks; //Array of checks that need to be complete to mark the task as complete

    [SerializeField] TaskSO assignedTask; //Task that will be marked as complete

    // Conditional statements

    public void CompleteCheck(int checkIndex)
    {
        //Ensure that the parameter isn't out of bounds
        if(checkIndex < 0 || checkIndex >= bChecks.Length)
        {
            Debug.Log("Check out of bounds");
            return;
        }

        bChecks[checkIndex] = true; //Indicate that this check is completed

        checkCompletion(); //Check for completion of this room
    }

    private void checkCompletion()
    {
        int checks = bChecks.Length; //Get the total check amount

        int correctChecks = 0; // Counter

        //Loop through the checks
        for (int check = 0; check < bChecks.Length; check++)
        {
            if (bChecks[check]) correctChecks++; //Increment if true

            else if (!bChecks[check]) continue;
        }

        if (correctChecks == bChecks.Length)
        {
            Debug.Log($"Task Complete: {assignedTask.name}");
            TaskManager.instance.MarkTaskComplete(assignedTask);
        }
    }

}
