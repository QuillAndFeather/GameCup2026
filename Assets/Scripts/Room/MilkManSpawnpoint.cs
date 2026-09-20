using UnityEngine;

public class MilkManSpawnpoint : MonoBehaviour
{
    private Roomv2 parentRoom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentRoom = transform.parent.GetComponent<Roomv2>();
        parentRoom.SetMilkManSpawnpoint(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
