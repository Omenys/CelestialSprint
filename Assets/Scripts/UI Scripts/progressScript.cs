using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class progressScript : MonoBehaviour
{
    float levelDurationInSeconds = 10; // 10 seconds
    [SerializeField] int portalsAmountToWin;
    float gameDurationInSeconds;
    float progressBarRate;
    float currentProgress = 0;
    [SerializeField] Image progressBar;
    bool hasWon = false;
    [SerializeField] bool greenPortal = false;


    void Start()
    {
        gameDurationInSeconds = levelDurationInSeconds * portalsAmountToWin;
        progressBarRate = 0.1f / portalsAmountToWin;
    }

    void Update()
    {
        theGameDuration();
        if (greenPortal)
            inAGreenPortal();
    }

    void victory() // The player went through all the portals :D
    {
        SceneManager.LoadSceneAsync("Victory UI", LoadSceneMode.Additive);
        MusicPlayer.playMusic("victory");
        SceneManager.UnloadSceneAsync("Gameplay UI");
    }

    void theGameDuration()
    {
        if (currentProgress < 1)
        {
            currentProgress += progressBarRate * Time.deltaTime;
            progressBar.fillAmount = currentProgress;
        }
        else
        {
            if(!hasWon)
            {
                hasWon = true;
                victory();
            }
        }
    }

    public void inAGreenPortal() // Must be called while the player is inside a green portal (Gameplay)
    {
        if (currentProgress < 1)
            currentProgress += progressBarRate * Time.deltaTime;
    }
}
