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

    [Header("Dialogue")]

    [SerializeField] DialogueLinesSO intro; //Intro dialogue line

    public PlayerController controller;

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
        DisableAllScenes();
        LoadRoomByName("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Disable all the scenes
    private void DisableAllScenes()
    {
        for (int room = 0; room < objectPrefabs.Count; room++)
        {
            objectPrefabs[room].SetActive(false);
        }
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

        //Disable scenes
        DisableAllScenes();

        //For loop to go between scenes, enabling only the input
        for (int room = 0; room < objectPrefabs.Count; room++)
        {
            if (objectPrefabs[room].name == roomName) objectPrefabs[room].SetActive(true); //Enable the room

            else objectPrefabs[room].SetActive(false); //Disable the room
        }
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
        
        LoadRoomByName("FrontYard");

        DialogueManager.instance.WriteText(DialogueManager.instance.GetRandomLine(intro)); //Play the intro
    }
    public void LoadCredits()
    {
        Debug.Log("Loading Credits");
        LoadRoomByName("CreditsRoom");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
    public void GoToMain()
    {
        Debug.Log("Going to Main Menu");
        LoadRoomByName("MainMenu");
    }
}
