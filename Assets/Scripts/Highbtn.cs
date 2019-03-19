using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Highbtn : MonoBehaviour
{
    public Button high_button;
    // Start is called before the first frame update
    void changeScene()
    {
        SceneManager.LoadScene("high_scores");
    }
    void Start()
    {
        high_button.onClick.AddListener(changeScene);
    }
}

