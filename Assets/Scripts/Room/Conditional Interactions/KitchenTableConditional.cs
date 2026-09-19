using UnityEngine;

public class KitchenTableConditional : TaskConditionInteractable
{
    public override void CheckToMark(int index)
    {
        if (!bCheckMark(previousNeededIndex))
        {
            Debug.Log("Previous task not complete");
            return; //Return if the prior criteria isn't met
        }

        assignedRoom.CompleteCheck(index); //Mark the check as complete
    }
}
