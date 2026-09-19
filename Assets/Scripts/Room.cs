using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    public List<SpawnObject> objectSpawns = new();
    public GameObject playerSpawn;
    public GameObject milkManSpawn;
    public GameManager gameManager;
    public GameObject milkManPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.instance;
        gameManager.rooms.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRoom(GameObject taskPrefab)
    {
        gameManager.player.transform.position = playerSpawn.transform.position; // teleport player to room
        SpawnObject(taskPrefab); // spawn task object in room
        SpawnMilkMan(); // spawn choco milk man in room
    }

    private void SpawnObject(GameObject objectToSpawn)
    {
        int spawn = Random.Range(0, objectSpawns.Count); // pick a random spawn location
        Instantiate(objectToSpawn, objectSpawns[spawn].transform.position, Quaternion.identity); // spawn the object at that location
    }

    private void SpawnMilkMan()
    {
        Instantiate(milkManPrefab, milkManSpawn.transform.position, Quaternion.identity);
    }
}
