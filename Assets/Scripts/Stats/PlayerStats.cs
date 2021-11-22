using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    int regeneration = 1;
    float regenerationRate; //time in seconds
    private float second;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Die()
    {
        base.Die();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("DiedScreen");
    }

    public void healthRegen()
    {
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
