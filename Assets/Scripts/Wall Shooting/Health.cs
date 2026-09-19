using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public AudioClip takeDamageSound;
    public AudioSource audioSource;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (takeDamageSound != null)
        {
            audioSource.PlayOneShot(takeDamageSound);
        }
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }   
    }
}
