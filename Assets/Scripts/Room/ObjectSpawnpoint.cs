using UnityEngine;

public class ObjectSpawnpoint : MonoBehaviour
{
    private Room parentRoom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentRoom = transform.parent.GetComponent<Room>();
        parentRoom.AddObjectSpawnpoint(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
