using UnityEngine;
 
public class AutomaticDoor : MonoBehaviour
{

    public GameObject rotatingDoor;

    public float maximumOpening = 0f;
    public float maximumClosing = 100f;

    public float movementSpeed = 50f;

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
            if (rotatingDoor.transform.rotation.z > maximumOpening)
            {
                rotatingDoor.transform.Rotate(0f, 0f, -movementSpeed * Time.deltaTime);
                Debug.Log("HERE");
            }
        }
        else
        {
            if (rotatingDoor.transform.rotation.z < maximumClosing)
            {
                rotatingDoor.transform.Rotate(0f, 0f, movementSpeed * Time.deltaTime);
                Debug.Log("THERE");
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