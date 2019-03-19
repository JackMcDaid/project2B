using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exitbtn : MonoBehaviour
{
    public Button exit_button;
    // Start is called before the first frame update
    void exit()
    {
        Application.Quit();
    }
    void Start()
    {
        exit_button.onClick.AddListener(exit);
    }
}


