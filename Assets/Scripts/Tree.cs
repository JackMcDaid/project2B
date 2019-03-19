using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public bool mouseclicked = false;
    public GameObject Apple;
    bool left;
    int keepgoing;
    int wait;
    public float speed;
    GameObject player;
    PlayerScript ps;
    // Start is called before the first frame update
    void Start()
    {
        left = Random.Range(0, 1) > .5;
        keepgoing = (int)Random.Range(4, 20);
        wait = (int)Random.Range(30, 90);
        player = GameObject.Find("Player");
        ps = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.lives > 0)
        {
            if (!mouseclicked)
            {
                if (Input.GetMouseButtonDown(0))
                    mouseclicked = true;
            }
            else
            {
                if (transform.position.x > (float)-3.75 && transform.position.x < (float)3.75)
                {
                    if (keepgoing > 0)
                    {
                        if (left)
                        {
                            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
                            keepgoing--;
                        }
                        else
                        {
                            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                            keepgoing--;
                        }
                    }
                    else
                    {
                        keepgoing = (int)Random.Range(4, 20);
                        left = !left;
                    }

                }
                else
                {
                    keepgoing = (int)Random.Range(4, 20);
                    left = !left;
                    if (transform.position.x < (float)-3.75)
                    {
                        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
                    }
                }
                if (wait > 0)
                {
                    wait--;
                }
                else
                {
                    wait = (int)Random.Range(30, 90);
                    Instantiate(Apple, transform.position, Quaternion.identity);
                }
            }
        }
    }
}