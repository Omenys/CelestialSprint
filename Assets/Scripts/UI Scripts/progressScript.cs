using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class progressScript : MonoBehaviour
{
    [SerializeField] int portalsAmountToWin;
    [SerializeField] Image progressBar;
    [SerializeField] Image progressBarBackground;
    [SerializeField] Color progressBarColor;
    [SerializeField] Color progressBarBackgroundColor;
    bool hasWon = false;
    //[SerializeField] PortalEntered portalsCount;
    int uiPortalsCount = 0;
    int temp = 0;
    int tick = 0;
    int tick_two = 0;
    float alpha = 1.0f;


    void Start()
    {

    }

    void Update()
    {
        theGameDuration();
        if(Keyboard.current.rKey.wasPressedThisFrame)
        {
            uiPortalsCount++;
        }
    }

    void victory() // The player went through all the portals :D
    {
        SceneManager.LoadSceneAsync("Victory UI", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Gameplay UI");
    }

    void theGameDuration()
    {
        //if (uiPortalsCount != portalsCount.portalsEntered)
        if (uiPortalsCount != temp)
        {
            temp = uiPortalsCount;
            //uiPortalsCount = portalsCount.portalsEntered;
            progressBar.fillAmount = (float)uiPortalsCount / 10;
            Debug.Log((float)uiPortalsCount / 10);
            if(progressBar.fillAmount >= 1)
            {
                hasWon = true;
                MusicPlayer.playMusic("victory");
            }
        }
    }

    private void FixedUpdate() // Updates 50 times per second
    {
        if(hasWon)
        {
            if(tick > 75)
            {
                progressBar.color = new Color(progressBarColor.r, progressBarColor.g, progressBarColor.b, alpha);
                progressBarBackground.color = new Color(progressBarBackgroundColor.r, progressBarBackgroundColor.g, progressBarBackgroundColor.b, alpha);
                alpha -= 0.005f;
            }
            if (alpha <= 0)
            {
                tick_two++;
                if(tick_two > 150)
                {
                    victory();
                }
            }
            tick++;
        }
    }
}
