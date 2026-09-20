using UnityEngine;
using UnityEngine.UI;

public class JumpScareManager : MonoBehaviour
{
    public static JumpScareManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Image cleaning;
    public Image Cooking;
    public Image Books;
    public Image Vase;
    public Image Death;
    
    void Start()
    {
        cleaning.enabled = false;
        Cooking.enabled = false;
        Books.enabled = false;
        Vase.enabled = false;
        Death.enabled = false;
    }

}
