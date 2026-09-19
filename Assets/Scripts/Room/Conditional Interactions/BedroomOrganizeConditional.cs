using UnityEngine;

public class BedroomOrganizeConditional : TaskConditionInteractable
{
    public override void CheckToMark(int index)
    {
        assignedRoom.CompleteCheck(index); //Complete the check

        //Flash the full res image of organization

    }
}
