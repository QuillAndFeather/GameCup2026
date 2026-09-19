using UnityEngine;

public class PawnMover : Mover
{
    public override void Move(Vector2 direction, float speed)
    {
        // Simple positional movement. Use Rigidbody2D if you want physics-based motion.
        Vector3 displacement = new Vector3(direction.x, direction.y,0f).normalized * speed * Time.deltaTime;
        transform.position += displacement;
    }
}
