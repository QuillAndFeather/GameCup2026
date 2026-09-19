using UnityEngine;

public class Object : MonoBehaviour
{
    private Room ownerRoom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ownerRoom.spawnedObjects.Add(this.gameObject);
    }

    void OnDestroy()
    {
        ownerRoom.spawnedObjects.Remove(this.gameObject);
    }

    public void SetOwnerRoom(Room room)
    {
        ownerRoom = room;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
