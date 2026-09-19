using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject milkManPrefab;
    public PlayerPawn playerPawn;
    public List<GameObject> objectPrefabs = new();
    public GameObject currentObjectPrefab;
    public List<Room> rooms = new();
    public Room currentRoom;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
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

    public void HandleMilkManCollision()
    {
        //todo: gameover screen?
        ExitRoom();
    }

    private GameObject GetTaskPrefab()
    {
        //todo: ask task manager which object prefab to return
        return objectPrefabs[0];
    }

    public void EnterRoom(Room room) // this function will be called by interactable door objects
    {
        currentRoom = room;
        currentObjectPrefab = GetTaskPrefab();
        currentRoom.StartRoom(currentObjectPrefab);
    }

    public void ExitRoom()
    {
        currentRoom.EndRoom();
    }
    public void StartGame()
    {
        RoomManger.instance.LoadRoomByName("LobbyRoom");
    }
    public void LoadCredits()
    {
        RoomManger.instance.LoadRoomByName("CreditsRoom");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
