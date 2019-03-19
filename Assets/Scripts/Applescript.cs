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
    {
        player = GameObject.Find("Player");
        ps = player.GetComponent<PlayerScript>();
        mouseclicked = ps.mouseclicked;
        Thwack = GameObject.Find("Thwack").GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ps.score += 20;
        Thwack.Play();
        Destroy(gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        if (mouseclicked)
        {
            if (this.transform.position.y < (float)-3.56)
            {
                Destroy(gameObject);
                ps.lives = ps.lives-1;
                mouseclicked = false;
            }
        }
    }
}
