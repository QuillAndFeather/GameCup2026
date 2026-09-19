using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ButtonCode : MonoBehaviour
{
    public Button Start,Credits, Quit;

    public void StartGame()
    {
        GameManager.instance.StartGame();
    }
    public void LoadCredits()
    {
        GameManager.instance.LoadCredits();
    }
    public void QuitGame()
    {
        GameManager.instance.QuitGame();
    }

}
