using UnityEngine;
using Unity.Cinemachine; // Ensure you use the updated namespace

public class FollowPawn : MonoBehaviour
{
    private void Update()
    {
       if(GameManager.instance.controller != null && GameManager.instance.controller.pawn != null) 
        transform.position = GameManager.instance.controller.pawn.transform.position;
    }
}
