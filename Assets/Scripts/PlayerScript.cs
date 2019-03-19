using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerScript: MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public bool mouseclicked = false;
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

    // Update is called once per frame
    void Update()
    {
        if (!mouseclicked)
        {
            if (Input.GetMouseButtonDown(0))
                mouseclicked = true;
        }
        if (mouseclicked && lives>0)
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
                else if (player.transform.position.x-(float).25 < -4.39)
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
                }else if(specialpos.x < -4.39)
                {
                    player.transform.position = new Vector3((float)-4.39, (float)-2.46, 2);
                }else if (specialpos.x > 4.39)
                {
                    player.transform.position = new Vector3((float)4.39, (float)-2.46, 2);
                }
                oldpos = Input.mousePosition;
            }
            
        }
        else if(mouseclicked)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
