using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour
{
    public GameObject MainMenuCanvas, ControlsMenuCanvas, VolumeMenuCanvas, DifficultyMenuCanvas,  MainCanvasFirstButton, ControlsCanvasFirstButton, ControlsCanvasClosedButton, VolumeCanvasFirstButton, VolumeCanvasClosedButton, DifficultyCanvasFirstButton, DifficultyCanvasClosedButton;

    public void RestartGame()
    {
        SceneManager.LoadScene("Prototype");
    }

    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    // public void Controls()
    // {
    //     SceneManager.LoadScene("Controls");
    // }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
            // Cursor.visible = true;
            // Cursor.lockState = CursorLockMode.None;
    }

    public void OpenControlsCanvas()
    {
        ControlsMenuCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ControlsCanvasFirstButton);
        MainMenuCanvas.SetActive(false);
        // Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.None;
    }

    public void CloseControlsCanvas()
    {
        ControlsMenuCanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ControlsCanvasClosedButton);
        MainMenuCanvas.SetActive(true);
    }

    public void OpenVolumeCanvas()
    {
        VolumeMenuCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(VolumeCanvasFirstButton);
        MainMenuCanvas.SetActive(false);
        // Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.None;
    }

    public void CloseVolumeCanvas()
    {
        VolumeMenuCanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(VolumeCanvasClosedButton);
        MainMenuCanvas.SetActive(true);
    }

    public void OpenDifficultyCanvas()
    {
        DifficultyMenuCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(DifficultyCanvasFirstButton);
        MainMenuCanvas.SetActive(false);
        // Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.None;
    }

    public void CloseDifficultyCanvas()
    {
        DifficultyMenuCanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(DifficultyCanvasClosedButton);
        MainMenuCanvas.SetActive(true);
    }

    public void ChosenDifficulty()
    {
        // it's ok
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }

}
