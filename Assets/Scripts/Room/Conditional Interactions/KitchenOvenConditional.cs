using UnityEngine;

public class KitchenOvenConditional : TaskConditionInteractable
{
    [SerializeField] GameObject chicken;
    float timeCompleted; //When this task was completed

    bool bTimerRunning;

    public override void CheckToMark(int index)
    {
        assignedRoom.CompleteCheck(index); //Complete the check automatically

        //Play the cinematic of oven
        JumpScareManager.instance.Cooking.SetActive(true);
        TskMaster.instance.DisableTaskList();
        timeCompleted = Time.time; //Set the current time
        bTimerRunning = true;


        //Disable Icon and Interaction
        ForceDisableIcon();

        chicken.SetActive(false);
    }
    private void Update()
    {

        if (Time.time >= timeCompleted + 2f && bTimerRunning)
        {
            // Do something

            GameManager.instance.controller.bCanMove = true;
            bTimerRunning = false;
            JumpScareManager.instance.Cooking.SetActive(false);
            TskMaster.instance.EnableTaskList();
        }
    }
}
