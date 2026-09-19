using UnityEngine;

public class MilkManPawn : MonoBehaviour
{
    private RoomManager roomManager;
    public PlayerPawn playerPawn;
    public Vector2 movementInput;

    public float speed;

    void Start()
    {
        roomManager = RoomManager.instance;
        playerPawn = roomManager.playerPawn;
    }

    void Update()
    {
      
        MoveTo(playerPawn.transform.position);

    }

    private void MoveTo(Vector2 position)
    {
      //todo: make the milk man reach the player after exactly 10 seconds
      //  Vector3 move = new Vector3(position.x, position.y, 0).normalized * speed * Time.deltaTime;
        //transform.position += move;

        transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }

}
