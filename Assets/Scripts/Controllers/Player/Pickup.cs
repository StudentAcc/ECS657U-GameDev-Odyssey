using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour {
    public float pickUpRange = 5;
    bool pickup;
    public GameObject batteryImage;
    public GameObject batteryStatus;
    public GameObject generatorImage;
    public GameObject generatorStatus;
    public GameObject rotorImage;
    public GameObject rotorStatus;
    public GameObject fusionCoreImage;
    public GameObject fusionCoreStatus;
    
    void Update() {
        if(pickup) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
            {
                GameObject obj = hit.transform.gameObject;
                if (obj.tag == "ShipPart") {
                    Destroy (obj);
                    if(obj.name == "Battery") {
                        batteryImage.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                        batteryStatus.GetComponent<Text>().text = "Collected";
                    }
                    if(obj.name == "Generator") {
                        generatorImage.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                        generatorStatus.GetComponent<Text>().text = "Collected";
                    }
                    if(obj.name == "Rotor") {
                        rotorImage.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                        rotorStatus.GetComponent<Text>().text = "Collected";
                    }
                    if(obj.name == "FusionCore") {
                        fusionCoreImage.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                        fusionCoreStatus.GetComponent<Text>().text = "Collected";
                    }
                }
            }
            pickup = false;
        }
    }

    public void OnPickupPressed() {
        pickup = true;
    }

}
