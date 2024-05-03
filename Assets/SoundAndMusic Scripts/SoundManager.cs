using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] AudioSource[] sounds;

    public static void PlaySound(AudioClip clip)
    {
        foreach(AudioSource s in instance.sounds)
        {
            if(!s.isPlaying)
            {
                s.clip = clip;
                s.Play();

                return;
            }
        }
    }
}
