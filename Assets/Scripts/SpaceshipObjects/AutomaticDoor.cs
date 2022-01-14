using UnityEngine;
 
public class AutomaticDoor : MonoBehaviour
{

    public GameObject rotatingDoor;

    public float maximumOpening;
    public float maximumClosing;

    public float movementSpeed;

    public AudioManager audio;

    bool playerIsHere;

    // Start is called before the first frame update
    void Start()
    {
        audio.playDoorSFX();
        audio.pauseDoorSFX();
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
                audio.resumeDoorSFX();
            }
            else
            {
                audio.pauseDoorSFX();
            }
        }
        else {
            if (rotatingDoor.transform.rotation.eulerAngles.z < maximumClosing)
            {
                rotatingDoor.transform.Rotate(0f, 0f, movementSpeed * Time.deltaTime);
                audio.resumeDoorSFX();
            }
            else
            {
                audio.pauseDoorSFX();
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