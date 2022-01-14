using UnityEngine;
 
public class AutomaticDoor : MonoBehaviour
{

    public GameObject rotatingDoor;

    public float maximumOpening = 1f;
    public float maximumClosing = 92f;

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
            if (rotatingDoor.transform.rotation.eulerAngles.z > maximumOpening)
            {
                rotatingDoor.transform.Rotate(0f, 0f, -movementSpeed * Time.deltaTime);
            }
        }
        else {
            if (rotatingDoor.transform.rotation.eulerAngles.z < maximumClosing)
            {
                rotatingDoor.transform.Rotate(0f, 0f, movementSpeed * Time.deltaTime);
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