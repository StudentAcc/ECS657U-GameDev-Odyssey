using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Pickup : MonoBehaviour {
    // Collecting and stashing spaceship parts
    public float pickUpRange = 5;
    bool pickup;
    //initialising ship repair parts and its different states
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

    //initialise variable to determine how many ship repair parts have been stashed
    private int stashedParts = 0;

    //initialise audio to play sound effects
    public AudioManager audio;
    bool audioPlaying;

    //initialise different menus so that game doesn't run when player is in pause menu
    public GameObject PauseMenu;
    public GameObject ControlsMenu;
    public GameObject DifficultyMenu;
    public GameObject VolumeMenu;

    

    void Start()
    {
        //audio.playFirstStashedVoice();
        //audio.pauseFirstStashedVoice();

        //audio.playSecondStashedVoice();
        //audio.pauseSecondStashedVoice();

        //audio.playThirdStashedVoice();
        //audio.pauseThirdStashedVoice();

        //audio.playFourthStashedVoice();
        //audio.pauseFourthStashedVoice();
    }
    
    void Update() {
        //if the user is in the main menu, pause the AI sphere talking
        if (PauseMenu.activeInHierarchy || ControlsMenu.activeInHierarchy || VolumeMenu.activeInHierarchy || DifficultyMenu.activeInHierarchy)
        {
            if (audio.firstStashedVoiceIsPlaying())
            {
                audio.pauseFirstStashedVoice();
            }
            if (audio.secondStashedVoiceIsPlaying())
            {
                audio.pauseSecondStashedVoice();
            }
            if (audio.thirdStashedVoiceIsPlaying())
            {
                audio.pauseThirdStashedVoice();
            }
            if (audio.fourthStashedVoiceIsPlaying())
            {
                audio.pauseFourthStashedVoice();
            }
        }
        //otherwise resume the AI sphere talking
        else
        {
            if (audioPlaying)
            {
                audio.unpauseFirstStashedVoice();
                audio.unpauseSecondStashedVoice();
                audio.unpauseThirdStashedVoice();
                audio.unpauseFourthStashedVoice();
            }
        }

        //if the user clicks the pickup/interact button, check to see what the user is attempting to pick up or interact with
        if (pickup) 
        {
            RaycastHit hit;
            //if the user clicks the pickup/interact button next to the ship repair parts, destroy the object and change the inventory menu to show the updated status
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
            {
                GameObject obj = hit.transform.gameObject;
                if (obj.tag == "ShipPart") {
                    Destroy(obj);
                    audio.partsCollectedSFX();
                    if (obj.name.Contains("Battery")) {
                        batteryImage.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                        batteryStatus.GetComponent<Text>().text = "Collected";
                    }
                    if(obj.name.Contains("Generator")) {
                        generatorImage.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                        generatorStatus.GetComponent<Text>().text = "Collected";
                    }
                    if(obj.name.Contains("Rotor")) {
                        rotorImage.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                        rotorStatus.GetComponent<Text>().text = "Collected";
                    }
                    if(obj.name.Contains("FusionCore")) {
                        fusionCoreImage.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                        fusionCoreStatus.GetComponent<Text>().text = "Collected";
                    }
                }
                //if the user clicks the pickup/interact button next to the ship repair parts 'redded' out inside the ship and the user has collected the parts, stash it onto the table and update the inventory menu to show the updated status
                if (obj.tag == "ShipPartDark") {
                    if(obj.name == "BatteryDark") {
                        if(batteryStatus.GetComponent<Text>().text == "Collected") {
                            Destroy(obj);
                            audio.partsStashedSFX();
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
                            audio.partsStashedSFX();
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
                            audio.partsStashedSFX();
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
                            audio.partsStashedSFX();
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
                // When player interacts with AI sphere, different dialogue is spoken based on how many parts stashed
                if (obj.tag == "AI") 
                {
                    if (stashedParts == 0)
                    {
                        audio.playFirstStashedVoice();
                        audioPlaying = true;
                    }
                    if (stashedParts == 1)
                    {
                        audio.playSecondStashedVoice();
                        audioPlaying = true;
                    }
                    if (stashedParts == 2)
                    {
                        audio.playThirdStashedVoice();
                        audioPlaying = true;
                    }
                    if (stashedParts == 3)
                    {
                        audio.playFourthStashedVoice();
                        audioPlaying = true;
                    }
                }
            }
            //if the user has stashed all the ship repair parts, load up the "WinScreen" scene and unlock the mouse
            if (stashedParts == 4)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("WinScreen");
            }
            pickup = false;
        }
    }

    //setter method that sets pickup to true when the user has pressed the pickup/interact button
    public void OnPickupPressed() {
        pickup = true;
    }

}
