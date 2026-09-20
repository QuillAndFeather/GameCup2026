using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    private GameObject spawnedObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
