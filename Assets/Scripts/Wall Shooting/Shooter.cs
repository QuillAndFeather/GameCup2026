using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        // spawn a bullet pointed towards the mouse cursor
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mDirection = (mPosition - transform.position);
        float mAngle = Mathf.Atan2(mDirection.y, mDirection.x) * Mathf.Rad2Deg;
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, 0f, mAngle));
    }
}
