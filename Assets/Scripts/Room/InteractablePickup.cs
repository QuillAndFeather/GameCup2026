using UnityEngine;

public class InteractablePickup : Interactable
{
    private RoomManager roomManager;
    private PickupTrigger objectTrigger;
    public int itemID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectTrigger = GetComponent<PickupTrigger>(); //Grab the component
        roomManager = RoomManager.instance;
    }

    public override void Interaction()
    {
        objectTrigger.PickupInteraction();
        roomManager.HandlePickupResult(itemID);
    }
}
