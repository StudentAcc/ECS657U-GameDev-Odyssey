using UnityEngine;

public class Target : MonoBehaviour
{
    // If health is 0 destroy target object
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
