using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public AudioSource deathClip;
    public float damageAmount;
    public bool destroyOnCollision = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Health otherHealth = other.GetComponent<Health>();
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(damageAmount);
        }
        if (destroyOnCollision)
        {
            if (deathClip != null)
            {
                AudioSource.PlayClipAtPoint(deathClip.clip, transform.position);
            }
            Destroy(gameObject);
        }
    }
}
