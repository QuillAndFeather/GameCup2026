using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] GameObject interactionIcon; //Icon to enable and disable once the player is within range or hitting the trigger respectfully

    public abstract void Interaction(); //Function for interacting with the object

    // Triggers and Function for Enabling and Disabling the Interaction Icon

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if(interactionIcon != null) interactionIcon.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (interactionIcon != null) interactionIcon.SetActive(false);
    }

    //Function to force the icon hidden, primarily used for entering the minigame
    public void ForceDisableIcon()
    {
        if (interactionIcon != null) interactionIcon.SetActive(false);
    }
}
