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
    {//instantiate all the bits that havn't been instantiated in-editor
        player = gameObject;
        textobj = GameObject.Find("TextBox");
        canvas = GameObject.Find("Canvas");
        oldpos = Input.mousePosition;
    }

    void push_hs()
    {//push the high scores
        int temp;
        for(int i = 1; i<11; i++)
        {//go through a list of ints 1-10 and perform a simple sort to push the lower values down
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
                    score = 0;
                }
            }
        }
        SceneManager.LoadScene("high_scores");
    }
    // Update is called once per frame
    void Update()
    {//on update
        if (!mouseclicked)//wait for mouse click
        {
            if (Input.GetMouseButtonDown(0))
                mouseclicked = true;
        }
        if (mouseclicked && lives > 0)
        {
            textobj.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score.ToString() + " Lives: " + lives.ToString();//score gui
            if (Input.GetKey(KeyCode.RightArrow))//player movement
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
            if (Input.mousePosition != oldpos)//if the mouse moves
            {//move the player
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
        else if (lives == 0 && tripgate)//if the player runs out of lives (occurs only once because of tripgate)
        {
            tripgate = false;
            push_hs();
        }
    }
}
