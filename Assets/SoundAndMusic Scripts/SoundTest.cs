using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    AudioSource[] BGMList;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        BGMList = FindObjectOfType<MusicManager>().musicList;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (index < BGMList.Length - 1 && !BGMList[index].isPlaying)
            {
                BGMList[index].Play();
            }
            else if (index < BGMList.Length - 1 && BGMList[index].isPlaying)
            {
                BGMList[index].Stop();
                index++;
                BGMList[index].Play();
            }
            else
            {
                BGMList[index].Stop();
                index = 0;
                BGMList[index].Play();
            }
        }

        if(Input.GetKeyDown(KeyCode.Minus))
            BGMList[index].volume -= 0.01f;

        if (Input.GetKeyDown(KeyCode.Equals))
            BGMList[index].volume += 0.01f;
    }
}
