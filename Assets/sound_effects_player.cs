using UnityEngine;
using UnityEngine.Audio;
using System.Collections;   
using System.Collections.Generic;

public class sound_effects_player : MonoBehaviour
{

    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3,background;


    public void Button1()
    {
        src.clip = sfx1;
        src.Play();
    }
    public void Button2()
    {
        src.clip = sfx2;
        src.Play();
    }
    public void Button3()
    {
        src.clip = sfx3;
        src.Play();
    }
    public void Canvas()
    {
        src.clip = background;
        src.Play();
    }
}
