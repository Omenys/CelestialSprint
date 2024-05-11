using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class progressScript : MonoBehaviour
{
    [SerializeField] int portalsAmountToWin;
    [SerializeField] public Image progressBar;
    [SerializeField] Image progressBarBackground;
    [SerializeField] Color progressBarColor;
    [SerializeField] Color progressBarBackgroundColor;
    bool hasWon = false;
    int tick = 0;
    int tick_two = 0;
    float alpha = 1.0f;


    void Start()
    {

    }

    void Update()
    {
        if (progressBar.fillAmount == 1)
        {
            hasWon = true;
            if(SceneManager.GetSceneByName("Portals").isLoaded && SceneManager.GetSceneByName("Hazards").isLoaded)
            {
                MusicPlayer.playMusic("victory");
                SceneManager.UnloadSceneAsync("Portals");
                SceneManager.UnloadSceneAsync("Hazards");
            }
        }
    }

    void victory() // The player went through all the portals :D
    {
        SceneManager.LoadSceneAsync("Victory UI", LoadSceneMode.Additive);
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
                if(tick_two == 150)
                {
                    victory();
                }
            }
            tick++;
        }
    }

    public void portalCollision()
    {
        progressBar.fillAmount += 0.1f;
    }
}
