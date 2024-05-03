using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTester : MonoBehaviour
{
    static List<AudioClip> BGMList;
    static AudioSource currentBGM;
    static float musicVolume = 0.5f;
    int index = -1;

    // Start is called before the first frame update
    void Start()
    {
        BGMList = FindObjectOfType<MusicList>().musicList;
        currentBGM = GetComponent<AudioSource>(); // Connecting the Empty Audio Source object here.
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (index)
            {
                case 0:
                    playMusic("main music");
                    break;
                case 1:
                    playMusic("game over");
                    break;
                case 2:
                    playMusic("victory");
                    break;
                case 3:
                    playMusic("credits");
                    break;
                default:
                    break;
            }
            if(index == 3)
                index = 0;
            else
                index++;
        }
    }

    public static void playMusic(string name)
    {
        foreach (AudioClip music in BGMList)
        {
            if (music.name == name)
            {
                if (currentBGM.isPlaying)
                    currentBGM.Stop();
                currentBGM.volume = musicVolume;
                currentBGM.clip = music;
                currentBGM.Play();
                return;
            }
        }
        //If the foreach loop fails then...
        Debug.Log("Couldn't find a Music named: \"" + name + "\"");
    }
}
