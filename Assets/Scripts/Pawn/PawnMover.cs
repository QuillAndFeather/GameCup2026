using UnityEngine;

public class PawnMover : Mover
{
    [Header("sprite renderer")]
    public SpriteRenderer spriteRenderer;
    public Sprite up, down, horzonatal,idel;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //Grab the sprite rendered component
    }

    public override void Move(Vector2 direction, float speed)
    {
        // Simple positional movement. Use Rigidbody2D if you want physics-based motion.
        Vector3 displacement = new Vector3(direction.x, direction.y,0f).normalized * speed * Time.deltaTime;
        transform.position += displacement;

        if (displacement.x == 0 && displacement.y == 0)
        {
            // idel
        }
        else
        {
            if (direction.x > 0)
            {
                //spriteRenderer.sprite = horzonatal;
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0)
            {
                //spriteRenderer.sprite = horzonatal;
                spriteRenderer.flipX = true;
            }
            if (displacement.y > 0)
            {
                //spriteRenderer.sprite = up;
            }
            else if (displacement.y < 0)
            {
                //spriteRenderer.sprite = down;
            }

        }
    }
}
