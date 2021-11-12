using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectBug : MonoBehaviour
{
    public Button primaryButton;
    
    void Start()
    {
        primaryButton.Select();
    }
}
