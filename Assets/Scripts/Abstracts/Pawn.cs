using Unity.VisualScripting;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    [Header("Controller")]
    public Controller controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public abstract void Move(Vector2 direction);

    public virtual void PossessedBy(Controller controller)
    {
        this.controller = controller;
    }
    public virtual void UnPossessed()
    {
        this.controller = null;
    }
    public virtual void OnDeath()
    {
        //do things
    }
    public virtual void onDestroy()
    {
        //do things
    }
    public virtual void interact() { 
    
    
    }
    public virtual void Shoot()
    {

    }
   

}
