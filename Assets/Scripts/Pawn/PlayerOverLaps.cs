using UnityEngine;

public class PlayerOverLaps : MonoBehaviour
{
    [SerializeField] DialogueLinesSO caughtLines; //Lines of dialogue to play when the player is caught

    [SerializeField] string roomToReturn; //Where should the player return if they are caught?

    [SerializeField] AudioPlayer audioPlayer; //Audio player

    void Start()
    {
        //audioPlayer = GetComponentInChildren<AudioPlayer>(); //Yes
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        MilkManPawn othermilk = other.GetComponent<MilkManPawn>();
        if (othermilk != null)
        {
            Debug.Log("Player has overlapped with MilkManPawn!");
            GameManager.instance.LoadRoomByName(roomToReturn); //Load into the specified room
            JumpScareManager.instance.Dysfunction();
            DialogueManager.instance.WriteText(DialogueManager.instance.GetRandomLine(caughtLines)); //Write a random line

            audioPlayer.PlayRandomSound();
        }
    }
}
