using System.Xml.Serialization;
using UnityEngine;

public class PlayerPawn : Pawn
{
    private RoomManager roomManager;
    [Header("Pawn Speed")]
    public float speed;
    [Header("Pawn Mover")]
    public Mover mover;

    [Header("Interaction")]
    public PlayerInteraction interaction;

    [Header("Attacking")]
    public Shooter shooter;

    [Header("Animation")]
    private Animator playerAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mover = GetComponent<Mover>();
        interaction = GetComponent<PlayerInteraction>();
        shooter = GetComponent<Shooter>();
        playerAnimator = GetComponent<Animator>();
        roomManager = RoomManager.instance;
    }
    
    // Update is called once per frame
    void Update()
    {

    }
    public override void Move(Vector2 pos) {

        if (pos.x != 0 || pos.y != 0) playerAnimator.SetBool("bMoving", true);

        else playerAnimator.SetBool("bMoving", false);

        mover.Move(pos, speed);
    }
   public override void interact() {

        playerAnimator.SetTrigger("tInteract");

        interaction.PInteraction();
   }
    void OnEnable()
    {
        if(GameManager.instance != null) GameManager.instance.controller.Possess(this);
    }

    void OnDisable()
    {
        if (GameManager.instance != null) GameManager.instance.controller.UnPossess();
    }


    public override void Shoot()
    {
        if (roomManager.isInCombat)
            shooter.Shoot();
    }
   

}
