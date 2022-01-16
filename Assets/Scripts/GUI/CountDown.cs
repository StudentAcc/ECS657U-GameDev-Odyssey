using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    // Oxygen timer goes red and plays sound when time is low
    [SerializeField] Image timeImage;
    [SerializeField] Text timeText;
    public float duration;
    public float currentTime;
    [SerializeField] float decreaseByShooting;
    [SerializeField] float decreaseBySprinting;
    public AudioManager Audio;

    public GameObject PauseMenu, ControlsMenu, VolumeMenu, DifficultyMenu;

    // Start is called before the first frame update
    void Start()
    {
        Audio.playCountdownSFX();
        Audio.pauseCountdownSFX();

        if (PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            duration = 900f;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            duration = 600f;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            duration = 600f;
        }
        else
        {
            // Debug.Log(PlayerPrefs.GetString("Difficulty"));
        }

        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    void Update()
    {
        if (currentTime <= 60)
        {
            timeImage.GetComponent<Image>().color = new Color32(255, 0, 0, 225);
        }
        else
        {
            timeImage.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
        }

        if (currentTime <= 60 && !PauseMenu.activeInHierarchy && !ControlsMenu.activeInHierarchy && !VolumeMenu.activeInHierarchy && !DifficultyMenu.activeInHierarchy)
        {
            Audio.unpauseCountdownSFX();
        }
        else
        {
            Audio.pauseCountdownSFX();
        }
    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0)
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;

        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("LoseScreen");
    }

    public void onShootDecreaseOxygen()
    {
        currentTime -= decreaseByShooting;
    }

    public void onSprintDecreaseOxygen()
    {
        currentTime -= decreaseBySprinting;
    }

    public void onCollisionOxygenPodsReplenishOxygen(int increase)
    {
        currentTime += increase;
        if (currentTime > duration)
        {
            currentTime = duration;
        }
    }
}
