using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    [Header("Player Controller")]
    public InputActionAsset inputAction;

    public bool bCanMove = true; //Can the player currently move?

    void Awake()
    {
    }
    public override void Decision()
    {
        if (bCanMove) //Player can currently move
        {
            Vector2 movement = inputAction["Move"].ReadValue<Vector2>();
            //Debug.Log("Player Movement Input: " + movement);
            pawn.Move(movement);

            if (inputAction["Interact"].WasPressedThisFrame())
            {
                pawn.interact();
            }

            if (inputAction["Shoot"].WasPressedThisFrame())
            {
                pawn.Shoot();
            }

            base.Decision();
        }
        else //Player cannot move, primarily due dialogue popups
        {
            if (inputAction["Interact"].WasPressedThisFrame())
            {
                DialogueManager.instance.DisableTextBox(); //Hide the text box

                SwapMovementState(); //Allow the player to move again
            }
        }
    }

    //Swap the state in which the player can move
    public void SwapMovementState()
    {
        bCanMove = !bCanMove;
    }
}
