using System;
using Unity.VectorGraphics;
using UnityEngine;


[Serializable]
public class Scene
{
    public string name; //Scene name for swapping purposes

    public GameObject sceneGameObject; //Game object of the scene
}

public class SceneSwapper : MonoBehaviour
{
    public static SceneSwapper instance; //Instance of the sceneswapper

    [SerializeField] Scene[] gameScenes; //Array of game scenes

    private void Awake()
    {
        instance = this; //Set the instance
    }

    // Scene Swapping

    public void CloseAllScenes()
    {
        for (int scene = 0; scene < gameScenes.Length; scene++)
        {
            gameScenes[scene].sceneGameObject.SetActive(false);
        }
    }

    public void OpenSpecificScene(string sceneName)
    {
        //Loop through the scenes in search for any matching names
        for (int scene = 0; scene < gameScenes.Length; scene++)
        {
            //Once a scene name matches, enable the gameobject and stop the execution
            if (gameScenes[scene].name == sceneName)
            {
                gameScenes[scene].sceneGameObject.SetActive(true);
                break;
            }
        }
    }

    public void SwapScene(string newScene)
    {
        CloseAllScenes(); //Close all scenes

        //Loop through the scenes in search for any matching names
        for (int scene = 0; scene < gameScenes.Length; scene++)
        {
            //Once a scene name matches, enable the gameobject and stop the execution
            if (gameScenes[scene].name == newScene)
            {
                gameScenes[scene].sceneGameObject.SetActive(true);
                break;
            }
        }
    }
}
