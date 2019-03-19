using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Startbtn : MonoBehaviour
{
    public Button start_button;
    void changeScene()
    {
        SceneManager.LoadScene("main_game");
    }
    void Start()//basic button script
    {
        start_button.onClick.AddListener(changeScene);
    }
}
