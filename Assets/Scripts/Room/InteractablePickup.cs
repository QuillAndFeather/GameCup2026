using UnityEngine;

public class InteractablePickup : Interactable
{
    private InteractTrigger objectTrigger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectTrigger = GetComponent<InteractTrigger>(); //Grab the component
    }

    public override void Interaction()
    {
        objectTrigger.PickupInteraction();
    }
}
