using System;
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

    public GameObject cleaning;
    public GameObject Cooking;
    public GameObject Books;
    public GameObject Vase;
    public GameObject Death;
    
    void Start()
    {
        cleaning.SetActive(false);
        Cooking.SetActive(false);
        Books.SetActive(false);
        Vase.SetActive(false);
        Death.SetActive(false);
    }
}
