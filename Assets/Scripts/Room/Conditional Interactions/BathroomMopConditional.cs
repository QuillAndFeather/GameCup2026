using UnityEngine;

public class BathroomMopConditional : TaskConditionInteractable
{
    float timeCompleted; //When this task was completed

    bool bTimerRunning;

    public override void CheckToMark(int index)
    {
       
        assignedRoom.CompleteCheck(index); //Mark the check as complete


        //Play the flashbang image of cleaning
        GameManager.instance.controller.bCanMove = false;

        JumpScareManager.instance.cleaning.enabled = true;

        //Disable Icon and Interaction
        ForceDisableIcon();

        timeCompleted = Time.time; //Set the current time
        bTimerRunning = true;
    }
    private void Update()
    {
        
        if(Time.time >= timeCompleted + 2f && bTimerRunning)
        {
            // Do something

            GameManager.instance.controller.bCanMove = true;
            bTimerRunning=false;
            JumpScareManager.instance.cleaning.enabled = false;
        } 
    }
}
