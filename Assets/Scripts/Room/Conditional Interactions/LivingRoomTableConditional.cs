using UnityEngine;

public class LivingRoomTableConditional : TaskConditionInteractable
{
    [SerializeField] GameObject pot;

    public override void CheckToMark(int index)
    {
        if (!bCheckMark(previousNeededIndex))
        {
            Debug.Log("Previous task not complete");
            return; //Return if the prior criteria isn't met
        }

        assignedRoom.CompleteCheck(index); //Mark the check as complete

        //Disable Icon and Interaction
        ForceDisableIcon();

        pot.SetActive(true);
    }
}
