using UnityEngine;

public class MilkManSpawnpoint : MonoBehaviour
{
    private Room parentRoom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentRoom = transform.parent.GetComponent<Room>();
        parentRoom.SetMilkManSpawnpoint(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
