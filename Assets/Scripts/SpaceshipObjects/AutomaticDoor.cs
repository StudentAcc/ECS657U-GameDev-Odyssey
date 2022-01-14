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
                audio.playDoorSFX();
            }

        }
        else {
            if (rotatingDoor.transform.rotation.eulerAngles.z < maximumClosing)
            {
                rotatingDoor.transform.Rotate(0f, 0f, movementSpeed * Time.deltaTime);
                audio.playDoorSFX();
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