using UnityEngine;

public abstract class TaskConditionInteractable : Interactable
{
    public int checkIndex; //Index of the check to conduct

    public int previousNeededIndex; //Index that has to be complete before this one

    public override void Interaction()
    {
        CheckToMark(checkIndex); //Conduct the check to mark
    }

    public RoomConditionManager assignedRoom; //The room this interactable will speak to when marking off checks

    //Abstract for the check to mark, also to allow other conditions to be checked, and so on.
    public abstract void CheckToMark(int index);

    //Check if the conditional is true
    public bool bCheckMark(int index)
    {
        return assignedRoom.bChecks[index];
    }
}
