using UnityEngine;

public class KitchenOvenConditional : TaskConditionInteractable
{
    [SerializeField] GameObject chicken;

    public override void CheckToMark(int index)
    {
        assignedRoom.CompleteCheck(index); //Complete the check automatically

        //Play the cinematic of oven


        //Disable Icon and Interaction
        ForceDisableIcon();

        chicken.SetActive(false);
    }
}
