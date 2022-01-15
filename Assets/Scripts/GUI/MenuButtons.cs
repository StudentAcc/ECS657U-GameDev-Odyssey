using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public GameObject MainMenuCanvas, ControlsMenuCanvas, VolumeMenuCanvas, DifficultyMenuCanvas,  MainCanvasFirstButton, ControlsCanvasFirstButton, ControlsCanvasClosedButton, VolumeCanvasFirstButton, VolumeCanvasClosedButton, DifficultyCanvasFirstButton, DifficultyCanvasClosedButton;
    public Slider mouseSensitivitySlider;
    public Text DifficultyStatusText;
    [SerializeField] Image DifficultyStatus;

    
    private static readonly string FirstPlay = "FirstPlay";
    int firstPlayInt;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        //if this is player's first time playing, initialises difficulty to 'Easy' and mouse sensitivity to '2f'
        if (firstPlayInt == 0)
        {
            PlayerPrefs.SetString("Difficulty", "Easy");
            PlayerPrefs.SetFloat("Mouse Sensitivity", 2f);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            mouseSensitivitySlider.value = PlayerPrefs.GetFloat("Mouse Sensitivity");
        }
    }

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

    public void setDifficultyEasy()
    {
        PlayerPrefs.SetString("Difficulty", "Easy");
    }

    public void setDifficultyNormal()
    {
        PlayerPrefs.SetString("Difficulty", "Normal");
    }

    public void setDifficultyHard()
    {
        PlayerPrefs.SetString("Difficulty", "Hard");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void changeMouseSensitivity()
    {
        PlayerPrefs.SetFloat("Mouse Sensitivity", mouseSensitivitySlider.value);
    }


}
