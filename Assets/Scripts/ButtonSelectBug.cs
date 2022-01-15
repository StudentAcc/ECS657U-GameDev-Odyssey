using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectBug : MonoBehaviour
{
    // Fix for selecting first button in canvas bug
    public Button primaryButton;
    
    void Start()
    {
        primaryButton.Select();
    }
}
