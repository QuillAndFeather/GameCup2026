using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float maxCooldown;
    public float currentCooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown < 0f)
                currentCooldown = 0f;
        }
    }

    public void Shoot()
    {
        if (currentCooldown == 0f)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            currentCooldown = maxCooldown;
        }
    }
}
