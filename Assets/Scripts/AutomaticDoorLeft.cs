using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class AutomaticDoorLeft : MonoBehaviour
{

    public GameObject movingDoor;

    public float maximumOpening = 10f;
    public float maximumClosing = 0f;

    public float movementSpeed = 5f;

    bool playerIsHere;

    // Start is called before the first frame update
    void Start()
    {
        playerIsHere = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsHere)
        {
            if (movingDoor.transform.position.z < maximumOpening)
            {
                movingDoor.transform.Translate(0f, 0f, movementSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (movingDoor.transform.position.z > maximumClosing)
            {
                movingDoor.transform.Translate(0f, 0f, -movementSpeed * Time.deltaTime);
            }
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