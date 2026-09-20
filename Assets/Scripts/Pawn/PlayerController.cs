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
    private void OnEnable()
    {
        inputAction.Enable();
    }
    private void OnDisable()
    {
        inputAction.Disable();
    }
    public override void Decision()
    {
        if (pawn != null)
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

                if (inputAction["Attack"].WasPressedThisFrame())
                {
                    pawn.Shoot();
                }
            }
            else //Player cannot move, primarily due dialogue popups
            {
                if (inputAction["Interact"].WasPressedThisFrame())
                {
                    if (inputAction["Interact"].WasPressedThisFrame())
                    {
                        DialogueManager.instance.DisableTextBox(); //Hide the text box

                        SwapMovementState(); //Allow the player to move again
                    }
                }
            }
            

            base.Decision();
        }
    }

    //Swap the state in which the player can move
    public void SwapMovementState()
    {
        bCanMove = !bCanMove;
    }

    public override void Possess(Pawn pawn)
    {
        base.Possess(pawn);

        PlayerPawn pPawn = pawn.GetComponent<PlayerPawn>(); //Grab the player pawn

        if (pPawn is not null) //Null check
        {
            GameManager.instance.playerPawn = pPawn; //Set the pawn in the main game manager
        }
    }
}
