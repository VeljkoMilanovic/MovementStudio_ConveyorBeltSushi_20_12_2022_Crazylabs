using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource stoolSoundPlayer;
    public AudioSource coinsSoundPlayer;

    public void playStoolSFX()
    {
        stoolSoundPlayer.Play();
    }

    public void playCoinsSFX()
    {
        coinsSoundPlayer.Play();
    }
}
