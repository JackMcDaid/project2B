using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Applescript : MonoBehaviour
{
    GameObject player;
    PlayerScript ps;
    public bool mouseclicked;
    AudioSource Thwack;
    // Start is called before the first frame update
    void Awake()
    {//when it spawns as a clone/initializes
        //get all the info it'll need
        player = GameObject.Find("Player");
        ps = player.GetComponent<PlayerScript>();
        mouseclicked = ps.mouseclicked;
        Thwack = GameObject.Find("Thwack").GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {//if it touches the player, increase the score, play a sound, and destroy this object
        ps.score += 20;
        Thwack.Play();
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (mouseclicked)//if the game is going on and you miss the apple
        {
            if (this.transform.position.y < (float)-3.56)
            {//get rid of the apple and decrement lives
                Destroy(gameObject);
                ps.lives = ps.lives-1;
                mouseclicked = false;
            }
        }
    }
}
