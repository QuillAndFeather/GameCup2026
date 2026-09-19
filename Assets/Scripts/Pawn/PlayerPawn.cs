using System.Xml.Serialization;
using UnityEngine;

public class PlayerPawn : Pawn
{
    [Header("Pawn Speed")]
    public float speed;
    [Header("Pawn Mover")]
    public Mover mover;

    [Header("Interaction")]
    public PlayerInteraction interaction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mover = GetComponent<Mover>();
        interaction = GetComponent<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Move(Vector2 pos) {
        mover.Move(pos, speed);
    }
   public override void interact() {

        interaction.PInteraction();

   }
   

}
