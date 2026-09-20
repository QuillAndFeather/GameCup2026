using System.Collections;
using UnityEngine;

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

    public void Dysfunction()
    {
        StartCoroutine("DeathWait2");
    }

    IEnumerator DeathWait2()
    {
        Death.SetActive(true);
        TskMaster.instance.DisableTaskList();
        GameManager.instance.controller.bCanMove = false;
        yield return new WaitForSeconds(2);
        Death.SetActive(false);
        TskMaster.instance.EnableTaskList();

    }

}
