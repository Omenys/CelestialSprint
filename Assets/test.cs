using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    int tick = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (tick == 5)
        {
            MusicTester.playMusic("main music");
            SoundTester.playSound("Sound");
            enabled = false;
        }
        else
            tick++;
    }
}
