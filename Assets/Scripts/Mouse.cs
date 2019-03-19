using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public bool mouseclicked=false;

    // Update is called once per frame
    void Update()
    {
        if (!mouseclicked)
        {
            if (Input.GetMouseButtonDown(0))
                mouseclicked = true;
        }
    }
}
