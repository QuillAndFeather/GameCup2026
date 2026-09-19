using UnityEngine;

public class DoorInteractable : Interactable
{
    private TaskDoorTrigger assignedDoor; //Reference to the assigned door of this interactable

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        assignedDoor = GetComponent<TaskDoorTrigger>(); //Grab the component
    }

    // Interaction Override
    public override void Interaction()
    {
        assignedDoor.DoorInteraction();
    }
}
