using UnityEngine;

public class RoomManger : MonoBehaviour
{
   public static RoomManger instance;
   public GameObject[] rooms; // Array to hold all room GameObjects
    public GameObject LoobyRoom;
    public GameObject BrainRoom;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        { 
            Destroy(instance);
        }
        // Ensure all rooms are inactive at the start
        RoomOff();
    }
    public void LoadLoobyRoom()
    {
        LoobyRoom.SetActive(true);
        BrainRoom.SetActive(false);
    }
    public void LoadBrainRoom()
    {
        LoobyRoom.SetActive(false);
        BrainRoom.SetActive(true);
    }
    public void LoadRoom(GameObject room)
    {
        LoobyRoom.SetActive(false);
        BrainRoom.SetActive(false);
        room.SetActive(true);
    }
    public void LoadRoomByName(string roomName)
    {
        switch (roomName)
        {
            case "LoobyRoom":
                LoadRoom(LoobyRoom);
                break;
            case "BrainRoom":
                LoadRoom(BrainRoom);
                break;
            default:
                Debug.LogWarning($"Room '{roomName}' not found.");
                break;
        }
    }
    public void LoadRoomByIndex(int index)
    {
        switch (index)
        {
            case 0:
                LoadRoom(LoobyRoom);
                break;
            case 1:
                LoadRoom(BrainRoom);
                break;
            default:
                Debug.LogWarning($"Room index '{index}' is out of range.");
                break;
        }
    }
    public void RoomOff() {
       for(int i = 0; i < rooms.Length; i++)
        {
            rooms[i].SetActive(false);
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
