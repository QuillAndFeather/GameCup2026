using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    public List<ObjectSpawnpoint> objectSpawns = new();
    public List<GameObject> spawnedObjects = new();
    private GameManager gameManager;
    private GameObject playerObject;
    public GameObject playerSpawn;
    public GameObject milkManSpawn;
    public GameObject milkManObject;
    private GameObject milkManPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.instance;
        gameManager.rooms.Add(this);
        playerObject = gameManager.playerPawn.gameObject;
        milkManPrefab = gameManager.milkManPrefab;
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
            int spawn = Random.Range(0, objectSpawns.Count); // pick a random spawn location
            GameObject spawnedObject = Instantiate(objectToSpawn, objectSpawns[spawn].transform.position, Quaternion.identity);
            Object newObject = spawnedObject.GetComponent<Object>();
            newObject.ownerRoom = this;
        }
        else
        {
            Debug.LogWarning("Room is missing object spawn locations");
        }
    }

    private void SpawnMilkMan()
    {
        milkManObject = Instantiate(milkManPrefab, milkManSpawn.transform.position, Quaternion.identity);
    }

    public void AddObjectSpawnpoint(ObjectSpawnpoint spawnpoint)
    {
        objectSpawns.Add(spawnpoint);
    }

    public void SetPlayerSpawnpoint(GameObject spawnpoint)
    {
        playerSpawn = spawnpoint;
    }

    public void SetMilkManSpawnpoint(GameObject spawnpoint)
    {
        milkManSpawn = spawnpoint;
    }
}
