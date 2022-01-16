using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    // If health is 0 destroy target object
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
            Die();
    }

    //method that destroys game object
    void Die()
    {
        Destroy(gameObject);
    }
}
