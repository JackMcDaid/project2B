using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        string outstr = "";
        for(int i = 1; i<11; i++)//Use playerprefs to store a list of 10 values and then call them back out using concatenation and a for loop
        {
            outstr += string.Concat(string.Concat("\n",i),".) ");
            outstr += PlayerPrefs.GetInt(string.Concat("Hs",i), 0);
        }
        scoretext.text = outstr;

    }
}
