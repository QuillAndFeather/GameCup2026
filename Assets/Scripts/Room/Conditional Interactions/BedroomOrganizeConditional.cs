using UnityEngine;

public class BedroomOrganizeConditional : TaskConditionInteractable
{
    [SerializeField] GameObject bookMess;
    [SerializeField] GameObject organizedBooks;
    float timeCompleted; //When this task was completed

    bool bTimerRunning;
    public override void CheckToMark(int index)
    {
        assignedRoom.CompleteCheck(index); //Complete the check

        //Flash the full res image of organization
        JumpScareManager.instance.Books.SetActive(true);
        TskMaster.instance.DisableTaskList();

        timeCompleted = Time.time; //Set the current time
        bTimerRunning = true;


        //Disable Icon and Interaction
        ForceDisableIcon();

        bookMess.SetActive(false);
        organizedBooks.SetActive(true);
    }
    private void Update()
    {
        if (Time.time >= timeCompleted + 2f && bTimerRunning)
        {
            // Do something

            GameManager.instance.controller.bCanMove = true;
            bTimerRunning = false;
            JumpScareManager.instance.Books.SetActive(false);
            TskMaster.instance.EnableTaskList();
        }
    }
}
