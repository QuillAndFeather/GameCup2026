using UnityEngine;

public class PlayerOverLaps : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.instance;
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        MilkManPawn othermilk = other.GetComponent<MilkManPawn>();
        if (othermilk != null)
        {
           Debug.Log("Player has overlapped with MilkManPawn!");
           gameManager.HandleMilkManCollision();
        }
    }
}
