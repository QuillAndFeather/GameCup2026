using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MilkManPawn : MonoBehaviour
{
    private GameManager gameManager;
    public PlayerPawn playerPawn;
    public Vector2 movementInput;

    private Vector2 resetPoint; //Reset point if the player fails the level

    [SerializeField] TaskSO taskToRemove; //What task will this Milk Man Remove?

    public bool bCanMove = false;

    public float speed;

    void Start()
    {
        gameManager = GameManager.instance;

        playerPawn = gameManager.playerPawn;

        
    }

    void Update()
    {
      
        if(playerPawn is not null) MoveTo(playerPawn.transform.position);

    }

    private void MoveTo(Vector2 position)
    {
        if (!bCanMove) return;

      //todo: make the milk man reach the player after exactly 10 seconds
      //  Vector3 move = new Vector3(position.x, position.y, 0).normalized * speed * Time.deltaTime;
        //transform.position += move;

        transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }

    void OnEnable()
    {
        resetPoint = transform.position; //Get the reset point

        //Run the timer to allow the milk to move
        StartCoroutine("MoveTimer");
        Debug.Log("Start Timer");
    }

    private void OnDisable()
    {
        transform.position = resetPoint; //Reset to origin
    }

    IEnumerator MoveTimer()
    {
        yield return new WaitForSeconds(1);

        //If null, assign the player
        if (playerPawn is null)
        {
            playerPawn = gameManager.playerPawn;
        }

        bCanMove = true;
        Debug.Log("Timer done");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPawn player = collision.GetComponent<PlayerPawn>(); //Get the player pawn component to see if it is the player

        if (player is not null)
        {
            transform.position = resetPoint; //Reset the position
            bCanMove = false; //Needs to reset it's movement principle, one second headstart always

            if (taskToRemove is not null)
            {
                if (TaskManager.instance is not null)
                {
                    TaskManager.instance.RemoveActiveTask(taskToRemove);
                }

                if (TskMaster.instance is not null)
                {
                    TskMaster.instance.RemoveActiveTask(taskToRemove);
                }
            }
        }
    }
}
