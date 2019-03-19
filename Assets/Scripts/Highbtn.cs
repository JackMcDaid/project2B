using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Highbtn : MonoBehaviour
{
    public Button high_button;
    void changeScene()
    {
        SceneManager.LoadScene("high_scores");
    }
    void Start()
    {//simple button
        high_button.onClick.AddListener(changeScene);
    }
}

