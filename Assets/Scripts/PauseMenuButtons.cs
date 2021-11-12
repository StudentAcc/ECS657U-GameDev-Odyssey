using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuButtons : MonoBehaviour
{
    public GameObject PauseMenu, ControlsMenu, PauseFirstButton, ControlsFirstButton, ControlsClosedButton;

    public void PauseUnpause()
    {
        if (!PauseMenu.activeInHierarchy)
        {
            ControlsMenu.SetActive(false);
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseControls()
    {
        ControlsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ControlsClosedButton);
        PauseMenu.SetActive(true);
    }
}
