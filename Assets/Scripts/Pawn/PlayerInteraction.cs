using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Interactable inRangeInteractable; //Is there currently an interactable in range?
    //private bool isInteracting = false;
    //GameObject DoorToUse;
    //public void OnTriggerEnter2D(Collider2D other)
    //{
    //    DoorInteractable otherDoor = other.GetComponent<DoorInteractable>();
    //    if (otherDoor != null)
    //    {
    //        isInteracting = true;
    //        DoorToUse = other.gameObject;
    //    }
    //}
    //public void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (isInteracting) {
    //        isInteracting = false;
    //    }
    //}


    //public void Doorinteract()
    //{
    //    if (isInteracting)
    //    {
    //        DoorToUse.GetComponent<DoorInteractable>().Interaction();
    //        isInteracting = false;
    //    }
    //}

    public void PInteraction()
    {
        if (inRangeInteractable is not null) inRangeInteractable.Interaction();
    }
}
