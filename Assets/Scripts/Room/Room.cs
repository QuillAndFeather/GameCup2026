using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    public List<SpawnObject> objectSpawns = new();
    private GameObject playerObject;
    public GameObject playerSpawn;
    public GameObject milkManSpawn;
    private GameManager gameManager;
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

    private void SpawnObject(GameObject objectToSpawn)
    {
        if (objectSpawns.Count > 0)
        {
            int spawn = Random.Range(0, objectSpawns.Count); // pick a random spawn location
            Instantiate(objectToSpawn, objectSpawns[spawn].transform.position, Quaternion.identity); // spawn the object at that location
        }
        else
        {
            Debug.Log("Room is missing references to object spawn locations");
        }
    }

    private void SpawnMilkMan()
    {
        Instantiate(milkManPrefab, milkManSpawn.transform.position, Quaternion.identity);
    }

    public void AddObjectSpawnpoint(SpawnObject spawnpoint)
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
