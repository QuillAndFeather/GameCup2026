using UnityEngine;

public enum MovementType { MoveLeft, PatrolUpDown, PatrolLeftRight };
public class MovingWall : MonoBehaviour
{
    public Health health;
    public float maxMoveSpeed;
    public float patrolDuration;
    private float currentPatrolTime;
    private float currentMoveSpeed;
    private string currentDirection;
    [Header("MoveLeft, PatrolUpDown, PatrolLeftRight")]
    public MovementType movementType;

    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        currentMoveSpeed = health.currentHealth / health.maxHealth * maxMoveSpeed;

        if (movementType == MovementType.MoveLeft)
        {
            transform.Translate(Vector3.left * currentMoveSpeed * Time.deltaTime);
        }

        if (movementType == MovementType.PatrolUpDown)
        {
            if (currentDirection == "Up")
            {
                transform.Translate(Vector3.up * currentMoveSpeed * Time.deltaTime);
                currentPatrolTime -= Time.deltaTime;
                if (currentPatrolTime < 0)
                {
                    currentPatrolTime = 0;
                    currentDirection = "Down";
                    currentPatrolTime = patrolDuration;
                }
            }
            else
            {
                transform.Translate(Vector3.down * currentMoveSpeed * Time.deltaTime);
                currentPatrolTime -= Time.deltaTime;
                if (currentPatrolTime < 0)
                {
                    currentPatrolTime = 0;
                    currentDirection = "Up";
                    currentPatrolTime = patrolDuration;
                }
            }
        }

        if (movementType == MovementType.PatrolLeftRight)
        {
            if (currentDirection == "Left")
            {
                transform.Translate(Vector3.left * currentMoveSpeed * Time.deltaTime);
                currentPatrolTime -= Time.deltaTime;
                if (currentPatrolTime < 0)
                {
                    currentPatrolTime = 0;
                    currentDirection = "Right";
                    currentPatrolTime = patrolDuration;
                }
            }
            else
            {
                transform.Translate(Vector3.right * currentMoveSpeed * Time.deltaTime);
                currentPatrolTime -= Time.deltaTime;
                if (currentPatrolTime < 0)
                {
                    currentPatrolTime = 0;
                    currentDirection = "Left";
                    currentPatrolTime = patrolDuration;
                }
            }
        }
    }
}
