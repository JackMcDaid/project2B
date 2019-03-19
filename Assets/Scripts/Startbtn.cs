using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Startbtn : MonoBehaviour
{
    public Button start_button;
    // Start is called before the first frame update
    void changeScene()
    {
        SceneManager.LoadScene("main_game");
    }
    void Start()
    {
        start_button.onClick.AddListener(changeScene);
    }
}
