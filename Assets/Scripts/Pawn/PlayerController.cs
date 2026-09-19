using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    [Header("Player Controller")]
    public InputActionAsset inputAction;
    void Awake()
    {
    }
    public override void Decision()
    {
        Vector2 movement = inputAction["Move"].ReadValue<Vector2>();
        pawn.Move(movement);

        if (inputAction["Interact"].WasPressedThisFrame())
        {
            pawn.interact();
        }

        base.Decision();
    }
}
