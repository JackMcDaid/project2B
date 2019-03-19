using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute_btn_script : MonoBehaviour
{
    public Slider associated_slider;
    public Button mute_button;
    public AudioSource audio_source;
    public string PlayerPrefsID;
    // Start is called before the first frame update
    void mute()
    {
        PlayerPrefs.SetFloat(PlayerPrefsID, 0);
        associated_slider.value = 0;
        audio_source.volume = 0;
    }
    void slide(float val)
    {
        PlayerPrefs.SetFloat(PlayerPrefsID, val);
        audio_source.volume = val;
    }
    void Start()
    {
        associated_slider.value = PlayerPrefs.GetFloat(PlayerPrefsID, 100);
        audio_source.volume = PlayerPrefs.GetFloat(PlayerPrefsID, 100);
        mute_button.onClick.AddListener(mute);
        associated_slider.onValueChanged.AddListener(slide);
    }
}
