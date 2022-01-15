using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenPods : MonoBehaviour
{
    [SerializeField] int OxygenReplenish;

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
            GameObject.Find("OxygenBackground").GetComponent<CountDown>().onCollisionOxygenPodsReplenishOxygen(OxygenReplenish);

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
