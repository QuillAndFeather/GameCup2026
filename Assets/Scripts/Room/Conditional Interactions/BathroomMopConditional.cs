using UnityEngine;

public class BathroomMopConditional : TaskConditionInteractable
{
    public override void CheckToMark(int index)
    {
        assignedRoom.CompleteCheck(index); //Mark the check as complete

        //Play the flashbang image of cleaning


        //Disable Icon and Interaction
        ForceDisableIcon();
    }
}
