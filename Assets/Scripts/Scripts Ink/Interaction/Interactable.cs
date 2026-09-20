using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] GameObject interactionIcon; //Icon to enable and disable once the player is within range or hitting the trigger respectfully

    public bool bActivateIcon = true; //Should the icon activate?

    public bool bActivateOnTrigger; //Should this activate when the trigger is hit?

    public abstract void Interaction(); //Function for interacting with the object

    // Triggers and Function for Enabling and Disabling the Interaction Icon

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bActivateOnTrigger) //Force interaction if trigger is hit
        {
            Interaction();
            return;
        }

        if (!bActivateIcon) return; //Return if false

        PlayerPawn player = collision.GetComponent<PlayerPawn>(); //Attempt to grab the player component

        if (player is null) return;

        if(interactionIcon != null) interactionIcon.SetActive(true);

        player.interaction.interactableInRange = this;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!bActivateIcon) return; //Return if false

        PlayerPawn player = collision.GetComponent<PlayerPawn>(); //Attempt to grab the player component

        if (player is null) return;

        if (interactionIcon != null) interactionIcon.SetActive(false);

        player.interaction.interactableInRange = null;
    }

    //Function to force the icon hidden, primarily used for entering the minigame
    public void ForceDisableIcon()
    {
        if (interactionIcon != null) interactionIcon.SetActive(false);

        bActivateIcon = false;
    }
}
