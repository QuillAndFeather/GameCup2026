using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    [Header("Pawn")]
    public Pawn pawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Decision();
    }

    // Default implementation; make virtual if you want subclasses to override
    public virtual void Possess(Pawn pawn)
    {
        this.pawn = pawn;
    }
    public virtual void UnPossess()
    {
        this.pawn = null;
    }
    public virtual void Decision (){ 
        //do things
    }
}
