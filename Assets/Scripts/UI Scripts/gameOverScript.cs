using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class gameOverScript : MonoBehaviour
{
    int tick = 0;
    float alpha = 0;
    [SerializeField] float alphaGain;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] Color gameOverTextColor;
    [SerializeField] Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.color = gameOverTextColor;
    }

    private void FixedUpdate() // Updates 50 times per second
    {
        if(tick > 35 && alpha <= 1)
        {
            alpha += alphaGain;
            gameOverText.color = new Color(gameOverTextColor.r, gameOverTextColor.g, gameOverTextColor.b, alpha);
        }
        if(alpha > 1)
        {
            backButton.gameObject.SetActive(true);
        }
        tick++;
    }

    public void mainMenu()
    {
        MusicPlayer.playMusic("main music");
        UIHandler.isOnGame = false;
        SceneManager.UnloadSceneAsync("GameOver UI");
    }
}
