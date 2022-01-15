using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IntroStartGame : MonoBehaviour {    
    
    public void StartGame()
        {
            SceneManager.LoadScene("Prototype");
        }
}