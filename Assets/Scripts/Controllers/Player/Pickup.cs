using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
    public GameObject firstUpgradeStatus;
    public GameObject secondUpgradeStatus;
    public GameObject thirdUpgradeStatus;
    private int stashedParts = 0;
    public AudioManager audio;
    
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
                            audio.playInventoryPickUpSFX();
                            batteryStatus.GetComponent<Text>().text = "Stashed";
                            batteryFinal.SetActive(true);
                            stashedParts += 1;
                            GameObject.Find("Gun").GetComponent<GunController>().upgradeGun();
                            if(stashedParts == 1 ) {
                                firstUpgradeStatus.GetComponent<Text>().text = "Upgraded";
                                firstUpgradeStatus.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                            }
                            if(stashedParts == 2 ) {
                                secondUpgradeStatus.GetComponent<Text>().text = "Upgraded";
                                secondUpgradeStatus.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                            }
                            if(stashedParts == 3 ) {
                                thirdUpgradeStatus.GetComponent<Text>().text = "Upgraded";
                                thirdUpgradeStatus.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                            }
                        }
                    }
                    if(obj.name == "GeneratorDark") {
                        if(generatorStatus.GetComponent<Text>().text == "Collected") {
                            Destroy(obj);
                            audio.playInventoryPickUpSFX();
                            generatorStatus.GetComponent<Text>().text = "Stashed";
                            generatorFinal.SetActive(true);
                            stashedParts += 1;
                            GameObject.Find("Gun").GetComponent<GunController>().upgradeGun();
                            if (stashedParts == 1 ) {
                                firstUpgradeStatus.GetComponent<Text>().text = "Upgraded";
                                firstUpgradeStatus.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                            }
                            if(stashedParts == 2 ) {
                                secondUpgradeStatus.GetComponent<Text>().text = "Upgraded";
                                secondUpgradeStatus.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                            }
                            if(stashedParts == 3 ) {
                                thirdUpgradeStatus.GetComponent<Text>().text = "Upgraded";
                                thirdUpgradeStatus.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                            }
                        }
                    }
                    if(obj.name == "RotorDark") {
                        if(rotorStatus.GetComponent<Text>().text == "Collected") {
                            Destroy(obj);
                            audio.playInventoryPickUpSFX();
                            rotorStatus.GetComponent<Text>().text = "Stashed";
                            rotorFinal.SetActive(true);
                            stashedParts += 1;
                            GameObject.Find("Gun").GetComponent<GunController>().upgradeGun();
                            if (stashedParts == 1 ) {
                                firstUpgradeStatus.GetComponent<Text>().text = "Upgraded";
                                firstUpgradeStatus.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                            }
                            if(stashedParts == 2 ) {
                                secondUpgradeStatus.GetComponent<Text>().text = "Upgraded";
                                secondUpgradeStatus.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                            }
                            if(stashedParts == 3 ) {
                                thirdUpgradeStatus.GetComponent<Text>().text = "Upgraded";
                                thirdUpgradeStatus.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                            }
                        }
                    }
                    if(obj.name == "FusionCoreDark") {
                        if(fusionCoreStatus.GetComponent<Text>().text == "Collected") {
                            Destroy(obj);
                            audio.playInventoryPickUpSFX();
                            fusionCoreStatus.GetComponent<Text>().text = "Stashed";
                            fusionCoreFinal.SetActive(true);
                            stashedParts += 1;
                            GameObject.Find("Gun").GetComponent<GunController>().upgradeGun();
                            if (stashedParts == 1 ) {
                                firstUpgradeStatus.GetComponent<Text>().text = "Upgraded";
                                firstUpgradeStatus.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                            }
                            if(stashedParts == 2 ) {
                                secondUpgradeStatus.GetComponent<Text>().text = "Upgraded";
                                secondUpgradeStatus.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                            }
                            if(stashedParts == 3 ) {
                                thirdUpgradeStatus.GetComponent<Text>().text = "Upgraded";
                                thirdUpgradeStatus.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                            }
                        }
                    }
                }
                if (obj.tag == "AI") 
                {
                    if (stashedParts == 0)
                    {
                        audio.playFirstStashedVoice();
                    }
                    if (stashedParts == 1)
                    {
                        audio.playSecondStashedVoice();
                    }
                    if (stashedParts == 2)
                    {
                        audio.playThirdStashedVoice();
                    }
                    if (stashedParts == 3)
                    {
                        audio.playFourthStashedVoice();
                    }

                }
            }
            if (stashedParts == 4) {
                SceneManager.LoadScene("WinScreen");
            }
            pickup = false;
        }
    }

    public void OnPickupPressed() {
        pickup = true;
    }

}
