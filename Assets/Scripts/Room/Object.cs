using UnityEngine;

public class Object : MonoBehaviour
{
    public Room ownerRoom;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ownerRoom.spawnedObjects.Add(this.gameObject);
    }

    void OnDestroy()
    {
        ownerRoom.spawnedObjects.Remove(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
