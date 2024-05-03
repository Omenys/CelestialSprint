using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTester : MonoBehaviour
{

    static List<AudioSource> SFXList;
    static float sfxVolume = 0.5f;
    int index = 0;


    // Start is called before the first frame update
    void Start()
    {
        SFXList = FindObjectOfType<SoundsList>().soundsList;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch(index)
            {
                case 0:
                    playSound("teleport 1");
                    break;
                case 1:
                    playSound("teleport 2");
                    break;
                case 2:
                    playSound("teleport 3");
                    break;
                case 3:
                    playSound("healing");
                    break;
                case 4:
                    playSound("shield breaks");
                    break;
                case 5:
                    playSound("warning");
                    break;
                case 6:
                    playSound("ship breaking apart");
                    break;
                case 7:
                    playSound("game over sfx");
                    break;
                default:
                    break;
            }
        }

        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            if (index == 7)
                index = 0;
            else
                index++;
        }

        if (Input.GetKeyDown(KeyCode.LeftBracket))
            sfxVolume -= 0.01f;

        if (Input.GetKeyDown(KeyCode.RightBracket))
            sfxVolume += 0.01f;
    }

    public static void playSound(string name)
    {
        foreach (AudioSource sfx in SFXList)
        {
            if(sfx.name == name)
            {
                sfx.volume = sfxVolume;
                sfx.Play();
                return;
            }
        }
        //If the foreach loop fails then...
        Debug.Log("Couldn't find a SFX named: \"" + name + "\"");
    }
}
