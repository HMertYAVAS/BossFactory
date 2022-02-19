using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource soundControl;
    void Start()
    {
        soundControl=GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("sesdurum")==1)
        {
            soundControl.mute=false;
        }
        else
        {
            soundControl.mute=true;
        }
    }
}
