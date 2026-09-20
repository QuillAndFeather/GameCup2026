using UnityEngine;

public class LivingRoomTableConditional : TaskConditionInteractable
{
    float timeCompleted; //When this task was completed

    bool bTimerRunning;
    [SerializeField] GameObject pot;

    public override void CheckToMark(int index)
    {
        if (!bCheckMark(previousNeededIndex))
        {
            Debug.Log("Previous task not complete");
            return; //Return if the prior criteria isn't met
        }

        assignedRoom.CompleteCheck(index); //Mark the check as complete
        JumpScareManager.instance.Vase.SetActive(true);
        TskMaster.instance.DisableTaskList();
        timeCompleted = Time.time; //Set the current time
        bTimerRunning = true;

        //Disable Icon and Interaction
        ForceDisableIcon();

        pot.SetActive(true);
    }
    private void Update()
    {
        if (Time.time >= timeCompleted + 2f && bTimerRunning)
        {
            // Do something

            GameManager.instance.controller.bCanMove = true;
            bTimerRunning = false;
            JumpScareManager.instance.Vase.SetActive(false);
            TskMaster.instance.EnableTaskList();
        }
    }
}
