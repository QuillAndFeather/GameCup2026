using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Interactable interactableInRange; //Interactable in range

    public void PInteraction()
    {
        if (interactableInRange is not null) interactableInRange.Interaction();
    }
}
