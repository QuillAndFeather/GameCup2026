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
            // spawn a bullet pointed towards the mouse cursor
            Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mDirection = (mPosition - transform.position);
            float mAngle = Mathf.Atan2(mDirection.y, mDirection.x) * Mathf.Rad2Deg;
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, 0f, mAngle));
            currentCooldown = maxCooldown;
        }
    }
}
