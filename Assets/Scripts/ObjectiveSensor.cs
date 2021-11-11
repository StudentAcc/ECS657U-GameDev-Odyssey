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
        partsDetected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (partsDetected == partsTotal)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("WinScreen");
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