using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    int regeneration = 1;
    float regenerationRate; //time in seconds
    private float second;

    public override void Die()
    {
        base.Die();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("DiedScreen");
    }

    public void healthRegen(int newRegeneration)
    {
        regeneration = newRegeneration;
        if (currentHealth < maxHealth)
        {
            second += Time.deltaTime;
            if (second >= regenerationRate)
            {
                currentHealth = Mathf.Min(currentHealth + regeneration, maxHealth);
                second = 0;
            }
        }
    }
}
