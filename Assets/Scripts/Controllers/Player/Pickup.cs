using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour {
    public float pickUpRange = 5;
    bool pickup;
    public GameObject batteryImage;
    public GameObject batteryStatus;
    public GameObject batteryFinal;
    public GameObject generatorImage;
    public GameObject generatorStatus;
    public GameObject generatorFinal;
    public GameObject rotorImage;
    public GameObject rotorStatus;
    public GameObject rotorFinal;
    public GameObject fusionCoreImage;
    public GameObject fusionCoreStatus;
    public GameObject fusionCoreFinal;
    
    void Update() {
        if(pickup) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
            {
                GameObject obj = hit.transform.gameObject;
                if (obj.tag == "ShipPart") {
                    Destroy(obj);
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
                if (obj.tag == "ShipPartDark") {
                    if(obj.name == "BatteryDark") {
                        if(batteryStatus.GetComponent<Text>().text == "Collected") {
                            Destroy(obj);
                            batteryStatus.GetComponent<Text>().text = "Stashed";
                            batteryFinal.SetActive(true);
                        }
                    }
                    if(obj.name == "GeneratorDark") {
                        if(generatorStatus.GetComponent<Text>().text == "Collected") {
                            Destroy(obj);
                            generatorStatus.GetComponent<Text>().text = "Stashed";
                            generatorFinal.SetActive(true);
                        }
                    }
                    if(obj.name == "RotorDark") {
                        if(rotorStatus.GetComponent<Text>().text == "Collected") {
                            Destroy(obj);
                            rotorStatus.GetComponent<Text>().text = "Stashed";
                            rotorFinal.SetActive(true);
                        }
                    }
                    if(obj.name == "FusionCoreDark") {
                        if(fusionCoreStatus.GetComponent<Text>().text == "Collected") {
                            Destroy(obj);
                            fusionCoreStatus.GetComponent<Text>().text = "Stashed";
                            fusionCoreFinal.SetActive(true);
                        }
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
