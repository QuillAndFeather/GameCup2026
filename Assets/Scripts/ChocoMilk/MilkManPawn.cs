using UnityEngine;

public class MilkManPawn : MonoBehaviour
{
    private GameManager gameManager;
    public PlayerPawn playerPawn;
    public Vector2 movementInput;
    private float maxTimer = 10;
    private float currentTimer;

    public float speed;

    void Start()
    {
        gameManager = GameManager.instance;
        playerPawn = gameManager.playerPawn;
        currentTimer = maxTimer;
    }

    void Update()
    {
      
        MoveTo(playerPawn.transform.position);
        currentTimer -= Time.deltaTime;
        if (currentTimer < 1)
        {
            speed += .01f;
        }
    }

    private void MoveTo(Vector2 position)
    {
      //  Vector3 move = new Vector3(position.x, position.y, 0).normalized * speed * Time.deltaTime;
        //transform.position += move;


        transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }

}
