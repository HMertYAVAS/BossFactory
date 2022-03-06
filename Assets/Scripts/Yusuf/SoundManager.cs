using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource soundControl;

    public AudioClip collectBoxesSound;
    public AudioClip cashSound;
    void Start()
    {
        soundControl = GetComponent<AudioSource>();
    }
    public void PlayClipOneShot(AudioClip clip)
    {
        soundControl.PlayOneShot(clip);
    }
    public void PlayBoxesCollectSound()
    {
        soundControl.PlayOneShot(collectBoxesSound);
    }

    public void PlayerCashSound()
    {
        soundControl.PlayOneShot(cashSound);
    }
}
