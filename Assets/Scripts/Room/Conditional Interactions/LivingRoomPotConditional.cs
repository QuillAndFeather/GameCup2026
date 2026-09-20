using UnityEngine;

public class LivingRoomPotConditional : TaskConditionInteractable
{
    public override void CheckToMark(int index)
    {
        audioPlayer.PlayRandomSound(); //Play Sound

        assignedRoom.CompleteCheck(index); //Mark the check as complete

        //Disable Icon and Interaction
        ForceDisableIcon();
    }
}
