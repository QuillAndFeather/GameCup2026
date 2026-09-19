using UnityEngine;

public class KitchenOvenConditional : TaskConditionInteractable
{
    public override void CheckToMark(int index)
    {
        assignedRoom.CompleteCheck(index); //Complete the check automatically

        //Play the cinematic of oven

    }
}
