using UnityEngine;

public class LivingRoomPotConditional : TaskConditionInteractable
{
    public override void CheckToMark(int index)
    {
        assignedRoom.CompleteCheck(index); //Mark the check as complete

        //Play the full res image


        //Disable Icon and Interaction
        ForceDisableIcon();
    }
}
