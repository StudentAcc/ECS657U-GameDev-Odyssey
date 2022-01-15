using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenuButtons : MonoBehaviour
{
    // Pause menu actions
    public GameObject PauseMenu, ControlsMenu, VolumeMenu, DifficultyMenu, PauseFirstButton, ControlsFirstButton, ControlsClosedButton, VolumeFirstButton, VolumeClosedButton, DifficultyFirstButton, DifficultyClosedButton;
    public Text DifficultyStatusText;
    [SerializeField] Image DifficultyStatus;
    public AudioManager Audio;

    void Update()
    {
        DifficultyStatusText.text = "Difficulty: " + PlayerPrefs.GetString("Difficulty");
        if (PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            DifficultyStatus.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
        }
        if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            DifficultyStatus.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
        }
        if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            DifficultyStatus.GetComponent<Image>().color = new Color32(255, 0, 0, 225);
        }
    }

    public void PauseUnpause()
    {
        if (!PauseMenu.activeInHierarchy)
        {
            Audio.pauseMusic();
            Audio.playPauseSFX();
            
            ControlsMenu.SetActive(false);
            VolumeMenu.SetActive(false);
            DifficultyMenu.SetActive(false);
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            // Highlight first button to use in menu
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(PauseFirstButton);
        }
        else
        {
            Audio.unpauseMusic();
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            ControlsMenu.SetActive(false);
            VolumeMenu.SetActive(false);
            DifficultyMenu.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void OpenControls()
    {
        ControlsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ControlsFirstButton);
        PauseMenu.SetActive(false);
    }

    public void CloseControls()
    {
        ControlsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ControlsClosedButton);
        PauseMenu.SetActive(true);
    }

    public void OpenVolume()
    {
        VolumeMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(VolumeFirstButton);
        PauseMenu.SetActive(false);
    }

    public void CloseVolume()
    {
        VolumeMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(VolumeClosedButton);
        PauseMenu.SetActive(true);
    }

    public void OpenDifficulty()
    {
        DifficultyMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(DifficultyFirstButton);
        PauseMenu.SetActive(false);
    }

    public void CloseDifficulty()
    {
        DifficultyMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(DifficultyClosedButton);
        PauseMenu.SetActive(true);
    }
}
