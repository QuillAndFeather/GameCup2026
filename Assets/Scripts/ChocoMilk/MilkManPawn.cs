using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MilkManPawn : MonoBehaviour
{
    private RoomManager roomManager;
    public PlayerPawn playerPawn;
    public Vector2 movementInput;

    public bool bCanMove = false;

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
        if (!bCanMove) return;

      //todo: make the milk man reach the player after exactly 10 seconds
      //  Vector3 move = new Vector3(position.x, position.y, 0).normalized * speed * Time.deltaTime;
        //transform.position += move;

        transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }

    void OnEnable()
    {
        //Run the timer to allow the milk to move
        StartCoroutine("MoveTimer");
        Debug.Log("Start Timer");
    }

    IEnumerator MoveTimer()
    {
        yield return new WaitForSeconds(1);

        bCanMove = true;
        Debug.Log("Timer done");
    }
}
