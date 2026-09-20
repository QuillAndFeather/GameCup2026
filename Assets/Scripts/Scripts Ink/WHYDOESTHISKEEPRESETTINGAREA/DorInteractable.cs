using UnityEngine;

public class DorInteractable : Interactable
{
    private TDoorTrigger assignedDoor; //Reference to the assigned door of this interactable

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        assignedDoor = GetComponent<TDoorTrigger>(); //Grab the component
    }

    // Interaction Override
    public override void Interaction()
    {
        assignedDoor.DoorInteraction();

        if (bActivateOnTrigger) assignedDoor.DisplayTaskList(); //Display the task list if it is leaving a brain room
    }
}
