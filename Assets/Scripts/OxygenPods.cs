using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenPods : MonoBehaviour
{
    // Script for replenishing oxygen from pods around map
    [SerializeField] int OxygenReplenish;

    bool playerIsHere;
    public AudioManager Audio;

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
            GameObject.Find("OxygenBackground").GetComponent<CountDown>().onCollisionOxygenPodsReplenishOxygen(OxygenReplenish);
            Audio.playPickUpOxygenTanksSFX();
            Destroy(gameObject);
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
