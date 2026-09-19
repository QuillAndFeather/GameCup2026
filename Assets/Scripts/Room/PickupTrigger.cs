using UnityEngine;

public class PickupTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void PickupInteraction()
    {
        // Pick up object, log it, self destruct
        Debug.Log("Picked up object");
        Destroy(gameObject);
    }
}
