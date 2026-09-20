using UnityEngine;

public class PlayerOverLaps : MonoBehaviour
{
    [SerializeField] DialogueLinesSO caughtLines; //Lines of dialogue to play when the player is caught

    [SerializeField] string roomToReturn; //Where should the player return if they are caught?

    void Start()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        MilkManPawn othermilk = other.GetComponent<MilkManPawn>();
        if (othermilk != null)
        {
           Debug.Log("Player has overlapped with MilkManPawn!");
           GameManager.instance.LoadRoomByName(roomToReturn); //Load into the specified room

           DialogueManager.instance.WriteText(DialogueManager.instance.GetRandomLine(caughtLines)); //Write a random line
        }
    }
}
