using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTester : MonoBehaviour
{

    public static List<AudioSource> SFXList;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        SFXList = FindObjectOfType<SoundsList>().soundsList;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch(count)
            {
                case 0:
                    playSFX("teleport 1a");
                    break;
                case 1:
                    playSFX("teleport 2");
                    break;
                case 2:
                    playSFX("teleport 3");
                    break;
                case 3:
                    playSFX("healing");
                    break;
                case 4:
                    playSFX("shield breaks");
                    break;
                case 5:
                    playSFX("ship breaking apart");
                    break;
                case 6:
                    playSFX("game over sfx");
                    break;
                default:
                    break;
            }
            count++;
        }
    }

    public static void playSFX(string name)
    {
        foreach (AudioSource sfx in SFXList)
        {
            if(sfx.name == name)
            {
                sfx.Play();
                return;
            }
        }
        Debug.Log("Couldn't find a SFX named: \"" + name + "\"");
    }
}
