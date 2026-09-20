using UnityEngine;

public class BedroomOrganizeConditional : TaskConditionInteractable
{
    [SerializeField] GameObject bookMess;
    [SerializeField] GameObject organizedBooks;

    public override void CheckToMark(int index)
    {
        assignedRoom.CompleteCheck(index); //Complete the check

        //Flash the full res image of organization


        //Disable Icon and Interaction
        ForceDisableIcon();

        bookMess.SetActive(false);
        organizedBooks.SetActive(true);
    }
}
