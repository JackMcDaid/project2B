using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute_btn_script : MonoBehaviour
{//designed to work for both mute sound effects and mute music
    public Slider associated_slider;
    public Button mute_button;
    public AudioSource audio_source;
    public string PlayerPrefsID;
    // Start is called before the first frame update
    void mute()
    {//if the mute button is pressed set the volume, preference, and slider to 0
        PlayerPrefs.SetFloat(PlayerPrefsID, 0);
        associated_slider.value = 0;
        audio_source.volume = 0;
    }
    void slide(float val)
    {//if the slider is updated, change the playerpref and volume
        PlayerPrefs.SetFloat(PlayerPrefsID, val);
        audio_source.volume = val;
    }
    void Start()
    {//make some listeners and create defaults
        associated_slider.value = PlayerPrefs.GetFloat(PlayerPrefsID, 100);
        audio_source.volume = PlayerPrefs.GetFloat(PlayerPrefsID, 100);
        mute_button.onClick.AddListener(mute);
        associated_slider.onValueChanged.AddListener(slide);
    }
}
