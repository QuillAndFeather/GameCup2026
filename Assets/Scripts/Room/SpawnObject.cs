using UnityEngine;
using UnityEngine.Animations;

public class SpawnObject : MonoBehaviour
{
    private GameObject spawnedObject;
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

    public void spawnObject(GameObject objectToSpawn)
    {
        spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
    }

}
