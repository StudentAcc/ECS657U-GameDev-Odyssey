using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveSensor : MonoBehaviour
{

    public int partsTotal;
    public int partsDetected;

    // Start is called before the first frame update
    void Start()
    {
        partsTotal = 4;
        partsDetected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (partsDetected == partsTotal)
        {
            SceneManager.LoadScene("WinScreen");
        }
        else
        {
            Debug.Log("Currently detected: " + partsDetected + " ; Total parts: " + partsTotal);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ShipPart")
        {
            partsDetected += 1;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "ShipPart")
        {
            partsDetected -= 1;
        }
    }
}