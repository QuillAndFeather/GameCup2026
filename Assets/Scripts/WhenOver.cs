using UnityEngine;

public class WhenOver : MonoBehaviour
{
    public Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    public void OnAnimationEnded()
    {
        GameManager.instance.GoToMain();

    }
}
