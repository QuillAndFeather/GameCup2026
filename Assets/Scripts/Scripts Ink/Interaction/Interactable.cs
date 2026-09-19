using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] GameObject interactionIcon; //Icon to enable and disable once the player is within range or hitting the trigger respectfully

    public abstract void Interaction(); //Function for interacting with the object

    // Triggers and Function for Enabling and Disabling the Interaction Icon

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPawn player = collision.GetComponent<PlayerPawn>(); //Attempt to grab the player pawn

        if (player is null) return;

        if(interactionIcon != null) interactionIcon.SetActive(true);

        player.interaction.inRangeInteractable = this; //Set the interactable in range to this
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerPawn player = collision.GetComponent<PlayerPawn>(); //Attempt to grab the player pawn

        if (player is null) return;

        if (interactionIcon != null) interactionIcon.SetActive(false);

        player.interaction.inRangeInteractable = null; //Set the interactable in range to null
    }

    //Function to force the icon hidden, primarily used for entering the minigame
    public void ForceDisableIcon()
    {
        if (interactionIcon != null) interactionIcon.SetActive(false);
    }
}
