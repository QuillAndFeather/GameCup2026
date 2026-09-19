using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public Health health;
    public float maxMoveSpeed;
    public float currentMoveSpeed;

    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        currentMoveSpeed = health.currentHealth / health.maxHealth * maxMoveSpeed;
        transform.Translate(Vector3.left * currentMoveSpeed * Time.deltaTime);
    }
}
