using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exitbtn : MonoBehaviour
{
    public Button exit_button;
    void exit()
    {
        Application.Quit();
    }
    void Start()
    {//simple button
        exit_button.onClick.AddListener(exit);
    }
}


