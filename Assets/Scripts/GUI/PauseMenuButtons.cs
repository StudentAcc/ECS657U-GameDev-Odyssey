using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuButtons : MonoBehaviour
{
    public GameObject PauseMenu, ControlsMenu, VolumeMenu, PauseFirstButton, ControlsFirstButton, ControlsClosedButton, VolumeFirstButton, VolumeClosedButton;

    public void PauseUnpause()
    {
        if (!PauseMenu.activeInHierarchy)
        {
            ControlsMenu.SetActive(false);
            VolumeMenu.SetActive(false);
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(PauseFirstButton);
        }
        else
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            ControlsMenu.SetActive(false);
            VolumeMenu.SetActive(false);
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
}
