using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // Health system for NPCs in the world
    [SerializeField] public int maxHealth = 100;
    public int currentHealth { get; set; }

    public Stat damage;

    void Awake ()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage (int damage)
    {
        currentHealth -= damage;
        // Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die ()
    {
        // Debug.Log(transform.name + " died.");
    }
}
