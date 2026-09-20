using UnityEngine;

public class PlayerOverLaps : MonoBehaviour
{
    private RoomManager roomManager;
    void Start()
    {
        roomManager = RoomManager.instance;
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        MilkManPawn othermilk = other.GetComponent<MilkManPawn>();
        if (othermilk != null)
        {
           Debug.Log("Player has overlapped with MilkManPawn!");
           roomManager.HandleMilkManCollision();
        }
    }
}
