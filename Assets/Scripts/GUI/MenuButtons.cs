using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour
{
    public GameObject MainMenuCanvas, ControlsMenuCanvas, MainCanvasFirstButton, ControlsCanvasFirstButton, ControlsCanvasClosedButton;

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

    public void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }

}
