using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerScript: MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public bool mouseclicked = false;
    private bool tripgate = true;
    GameObject canvas;
    GameObject textobj;
    GameObject player;
    Vector3 oldpos;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        textobj = GameObject.Find("TextBox");
        canvas = GameObject.Find("Canvas");
        oldpos = Input.mousePosition;
    }

    void push_hs()
    {
        int temp;
        for(int i = 1; i<11; i++)
        {
            if (score != 0)
            {
                if (PlayerPrefs.HasKey(string.Concat("Hs", i)))
                {
                    if (PlayerPrefs.GetInt(string.Concat("Hs", i)) < score)
                    {
                        temp = PlayerPrefs.GetInt(string.Concat("Hs", i));
                        PlayerPrefs.SetInt(string.Concat("Hs", i), score);
                        score = temp;
                    }
                }
                else
                {
                    PlayerPrefs.SetInt(string.Concat("Hs",i), score);
                }
            }
        }
        SceneManager.LoadScene("high_scores");
    }
    // Update is called once per frame
    void Update()
    {
        if (!mouseclicked)
        {
            if (Input.GetMouseButtonDown(0))
                mouseclicked = true;
        }
        if (mouseclicked && lives > 0)
        {
            textobj.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score.ToString() + " Lives: " + lives.ToString();
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (player.transform.position.x + (float).25 < 4.39)
                {
                    player.transform.position = new Vector3(player.transform.position.x + (float).25, (float)-2.46, 2);
                }
                else if (player.transform.position.x + (float).25 > 4.39)
                {
                    player.transform.position = new Vector3((float)4.39, (float)-2.46, 2);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (player.transform.position.x - (float).25 > -4.39)
                {
                    player.transform.position = new Vector3(player.transform.position.x - (float).25, (float)-2.46, 2);
                }
                else if (player.transform.position.x - (float).25 < -4.39)
                {
                    player.transform.position = new Vector3((float)-4.39, (float)-2.46, 2);
                }

            }
            if (Input.mousePosition != oldpos)
            {
                Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                Vector3 specialpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (specialpos.x > -4.39 && specialpos.x < 4.39) {
                    player.transform.position = new Vector3(specialpos.x, (float)-2.46, 2);
                } else if (specialpos.x < -4.39)
                {
                    player.transform.position = new Vector3((float)-4.39, (float)-2.46, 2);
                } else if (specialpos.x > 4.39)
                {
                    player.transform.position = new Vector3((float)4.39, (float)-2.46, 2);
                }
                oldpos = Input.mousePosition;
            }

        }
        else if (lives == 0 && tripgate)
        {
            tripgate = false;
            push_hs();
        }
    }
}
