using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{

    [SerializeField] Image timeImage;
    [SerializeField] Text timeText;
    [SerializeField] float duration;
    public float currentTime;
    [SerializeField] float decreaseByShooting;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0)
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;

            if (currentTime <= 20)
            {
                timeImage.GetComponent<Image>().color = new Color32(255, 0, 0, 225);
            }
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("LoseScreen");
    }

    public void onShootDecreaseOxygen()
    {
        currentTime -= decreaseByShooting;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
