using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MusicPlayer : MonoBehaviour
{
    static List<AudioClip> BGMList;
    static AudioSource currentBGM;
    public static float musicVolume;
    float volumeAdjustMultiplier = 1;
    //int index = 0;
    bool increasingVol = false;
    bool decreasingVol = false;
    
    // Start is called before the first frame update
    void Start()
    {
        BGMList = FindObjectOfType<MusicList>().musicList;
        currentBGM = GetComponent<AudioSource>(); // Connecting the Empty Audio Source object here.
    }

    // Update is called once per frame
    void Update()
    {
        currentBGM.volume = musicVolume;

        /*if (Input.GetKeyDown(KeyCode.Return)) // Music player tester
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
        }*/

        if (Keyboard.current.minusKey.wasReleasedThisFrame || Keyboard.current.equalsKey.wasReleasedThisFrame)
        {
            volumeAdjustMultiplier = 1;
            increasingVol = false;
            decreasingVol = false;
        }
            
    }

    private void FixedUpdate() // Updates 50 times a second
    {
        if (increasingVol)
        {
            musicVolume += 0.001f * volumeAdjustMultiplier;
            if (musicVolume < 0.01)
                musicVolume += 0.015f;
            if (volumeAdjustMultiplier < 4.5f)
                volumeAdjustMultiplier += 0.01f;
        }
        else if (decreasingVol)
        {
            musicVolume -= 0.001f * volumeAdjustMultiplier;
            if (musicVolume > 0.99)
                musicVolume -= 0.015f;
            if (volumeAdjustMultiplier < 4.5f)
                volumeAdjustMultiplier += 0.01f;
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
                currentBGM.clip = music;
                currentBGM.Play();
                return;
            }
        }
        //If the foreach loop fails then...
        Debug.Log("Couldn't find a Music named: \"" + name + "\"");
    }

    public void OnMusicVolume(InputValue value)
    {
        if(value.Get<float>() > 0)
            increasingVol = true;
        else if(value.Get<float>() < 0)
            decreasingVol = true;
    }
}
