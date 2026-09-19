using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    // Each room requires 1 Player Spawn, at least 1 Object Spawnpoint, and at least 1 Milk Man Spawnpoint
    // Spawnpoints will populate automatically as long as the Room is their parent object
    [SerializeField] private GameObject playerSpawn;
    public List<ObjectSpawnpoint> objectSpawns = new();
    public List<MilkManSpawnpoint> milkManSpawns = new();
    public List<GameObject> spawnedObjects = new();
    private RoomManager roomManager;
    private GameObject playerObject;
    private GameObject milkManObject;
    private GameObject milkManPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roomManager = RoomManager.instance;
        roomManager.rooms.Add(this.gameObject);
        playerObject = roomManager.playerPawn.gameObject;
        milkManPrefab = roomManager.milkManPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRoom(GameObject taskPrefab)
    {
        playerObject.transform.position = playerSpawn.transform.position; // teleport player to room
        SpawnObject(taskPrefab); // spawn task object in room
        SpawnMilkMan(); // spawn choco milk man in room
    }

    public void EndRoom()
    {
        gameObject.SetActive(false);
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            Destroy(spawnedObjects[i]);
        }
        Destroy(milkManObject);
    }

    private void SpawnObject(GameObject objectToSpawn)
    {
        if (objectSpawns.Count > 0)
        {
            int objSpawn = Random.Range(0, objectSpawns.Count); // pick a random spawn location
            GameObject spawnedObject = Instantiate(objectToSpawn, objectSpawns[objSpawn].transform.position, Quaternion.identity);
            Object newObject = spawnedObject.GetComponent<Object>();
            newObject.SetOwnerRoom(this);
        }
        else
        {
            Debug.LogWarning("Room is missing object spawn locations");
        }
    }

    private void SpawnMilkMan()
    {
        if (milkManSpawns.Count > 0)
        {
            int milkSpawn = Random.Range(0, milkManSpawns.Count); // pick a random spawn location
            milkManObject = Instantiate(milkManPrefab, milkManSpawns[milkSpawn].transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Room is missing milk man spawn locations");
        }
    }

    public void AddObjectSpawnpoint(ObjectSpawnpoint spawnpoint)
    {
        objectSpawns.Add(spawnpoint);
    }

    public void SetPlayerSpawnpoint(GameObject spawnpoint)
    {
        playerSpawn = spawnpoint;
    }

    public void SetMilkManSpawnpoint(MilkManSpawnpoint spawnpoint)
    {
        milkManSpawns.Add(spawnpoint);
    }
}
