using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;
    public bool isInCombat;
    public GameObject milkManPrefab;
    public PlayerPawn playerPawn;
    public List<GameObject> objectPrefabs = new();
    public GameObject currentObjectPrefab;
    public Room currentRoom;
    public List<GameObject> rooms = new(); // List to hold all room GameObjects
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
        //switch (roomName)
        //{
        //    case "LoobyRoom":
        //        LoadRoom(LoobyRoom);
        //        break;
        //    case "BrainRoom":
        //        LoadRoom(BrainRoom);
        //        break;
        //    default:
        //        Debug.LogWarning($"Room '{roomName}' not found.");
        //        break;
        //}

        //For loop to go between scenes, enabling only the input
        for (int room = 0; room < rooms.Count; room++)
        {
            if (rooms[room].name == roomName) rooms[room].SetActive(true); //Enable the room

            else rooms[room].SetActive(false); //Disable the room
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
       for(int i = 0; i < rooms.Count; i++)
        {
            rooms[i].SetActive(false);
        }
    }

    public void HandlePickupResult(int pickedUpID)
    {
        //todo: get current task
        int taskID = 0;

        if (pickedUpID == taskID)
        {
            // mark room as completed if true
        }
    }

    public void HandleMilkManCollision()
    {
        //todo: take player back to previous room
        ExitRoom();
    }

    private GameObject GetTaskPrefab()
    {
        //todo: ask task manager which object prefab to return
        return objectPrefabs[0];
    }

    public void EnterRoom(Room room)
    {
        currentRoom = room;
        currentObjectPrefab = GetTaskPrefab();
        currentRoom.StartRoom(currentObjectPrefab);
    }

    public void ExitRoom()
    {
        currentRoom.EndRoom();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         LoadRoomByName("LoobyRoom");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
