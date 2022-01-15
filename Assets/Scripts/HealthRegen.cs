using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    [SerializeField] int newRegeneration;

    bool playerIsHere;

    // Start is called before the first frame update
    void Start()
    {
        playerIsHere = false;
        if (PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            newRegeneration = 1;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            newRegeneration = 1;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            newRegeneration = 0;
        }
        else
        {
            newRegeneration = 1;
            Debug.Log(PlayerPrefs.GetString("Difficulty"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsHere)
        {
            GameObject.Find("Player").GetComponent<PlayerStats>().healthRegen(newRegeneration);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsHere = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsHere = false;
        }
    }
}
