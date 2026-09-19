using UnityEngine;
using UnityEngine.UIElements;

public abstract class Mover : MonoBehaviour
{
    public float speed;

    public abstract void Move(Vector2 direction, float speed);

}
