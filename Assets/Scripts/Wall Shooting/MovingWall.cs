using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public Health health;
    public float maxMoveSpeed;
    public float patrolDuration;
    private float currentPatrolTime;
    private float currentMoveSpeed;
    private Transform startingPos;
    [Header("MoveLeft, PatrolUpDown, PatrolLeftRight")]
    public string mode;

    void Start()
    {
        health = GetComponent<Health>();
        startingPos = transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentMoveSpeed = health.currentHealth / health.maxHealth * maxMoveSpeed;

        if (mode == "MoveLeft")
        {
            transform.Translate(Vector3.left * currentMoveSpeed * Time.deltaTime);
        }

        if (mode == "PatrolUpDown")
        {
            currentPatrolTime = patrolDuration;
            while (currentPatrolTime > 0)
            {
                currentPatrolTime -= Time.deltaTime;
                transform.Translate(Vector3.up * currentMoveSpeed * Time.deltaTime);
            }
            currentPatrolTime = patrolDuration;
            while (currentPatrolTime > 0)
            {
                currentPatrolTime -= Time.deltaTime;
                transform.Translate(Vector3.down * currentMoveSpeed * Time.deltaTime);
            }
        }

        if (mode == "PatrolLeftRight")
        {
            currentPatrolTime = patrolDuration;
            while (currentPatrolTime > 0)
            {
                currentPatrolTime -= Time.deltaTime;
                transform.Translate(Vector3.left * currentMoveSpeed * Time.deltaTime);
            }
            currentPatrolTime = patrolDuration;
            while (currentPatrolTime > 0)
            {
                currentPatrolTime -= Time.deltaTime;
                transform.Translate(Vector3.right * currentMoveSpeed * Time.deltaTime);
            }
        }
    }
}
