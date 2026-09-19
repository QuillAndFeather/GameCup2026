using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool isInteracting = false;
    GameObject DoorToUse;
    public void OnTriggerEnter2D(Collider2D other)
    {
        DoorInteractable otherDoor = other.GetComponent<DoorInteractable>();
        if (otherDoor != null)
        {
            isInteracting = true;
            DoorToUse = other.gameObject;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (isInteracting) {
            isInteracting = false;
        }
    }


    public void Doorinteract()
    {
        if (isInteracting)
        {
            DoorToUse.GetComponent<DoorInteractable>().Interaction();
            isInteracting = false;
        }
    }
}
