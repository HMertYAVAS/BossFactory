using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnOff : MonoBehaviour
{
    public GameObject soundOn, soundOff;

    //static olmasý önemli
    public static string soundStation = "soundStation";

    public GameObject soundManager;

    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager");
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("soundStation") == 1)
        {
            soundOff.transform.gameObject.SetActive(false);
            soundOn.transform.gameObject.SetActive(true);
            soundManager.GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("soundStation", 1);
        }
        else
        {
            soundOff.transform.gameObject.SetActive(true);
            soundOn.transform.gameObject.SetActive(false);
            soundManager.GetComponent<AudioSource>().Pause();
        }
        VolumeOnOff();
    }

    public void VolumeOnOff()
    {
        if (PlayerPrefs.GetInt("soundStation") == 0)
        {
            soundOff.transform.gameObject.SetActive(false);
            soundOn.transform.gameObject.SetActive(true);
            PlayerPrefs.SetInt("soundStation", 1);
            soundManager.GetComponent<AudioSource>().Play();
        }
        else if (PlayerPrefs.GetInt("soundStation") == 1)
        {
            soundOff.transform.gameObject.SetActive(true);
            soundOn.transform.gameObject.SetActive(false);
            PlayerPrefs.SetInt("soundStation", 0);
            soundManager.GetComponent<AudioSource>().Pause();
        }
    }

}
