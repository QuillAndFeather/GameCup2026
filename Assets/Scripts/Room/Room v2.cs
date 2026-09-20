using UnityEngine;

public class Roomv2 : MonoBehaviour
{
    // Each brain room needs 1 player spawn and 1 milk man spawn
    private GameObject playerSpawn;
    private GameObject milkManSpawn;
    public GameObject playerObject;
    public GameObject milkManObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetRoom()
    {
        SpawnPlayer(); // teleport player to start
        SpawnMilkMan(); // teleport choco milk man to start
    }

    private void SpawnPlayer()
    {
        if (playerObject != null)
        {
            if (playerSpawn != null)
            {
                playerObject.transform.position = playerSpawn.transform.position; 
            }
            else
            {
                Debug.LogWarning("Player spawnpoint is null!");
            }
        }
        else
        {
            Debug.LogWarning("Player object is null!");
        }
    }

    private void SpawnMilkMan()
    {
        if (milkManSpawn != null)
        {
            if (milkManSpawn != null)
            {
                milkManObject.transform.position = milkManSpawn.transform.position; 
            }
            else
            {
                Debug.LogWarning("Milk man spawn is null");
            }
        }
        else
        {
            Debug.LogWarning("Milk man object is null!");
        }
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
