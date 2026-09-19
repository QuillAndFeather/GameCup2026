using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    public float remainingLifespan;
    public float maxLifespan;
    public bool hasCollided = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Translate(Vector3.right * .8f);
        remainingLifespan = maxLifespan;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        remainingLifespan -= Time.deltaTime;
        if (remainingLifespan <= 0 || hasCollided == true)
        {
            Destroy(gameObject);
        }
    }
}
