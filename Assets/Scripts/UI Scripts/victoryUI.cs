using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class victoryUI : MonoBehaviour
{
    float fuelScore;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] RawImage earth;
    int tick = 0;
    float alpha = 0;
    [SerializeField] float alphaRate;
    [SerializeField] Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        fuelScore = FindObjectOfType<fuelScript>().fuelLeft;
        fuelScore = (int)fuelScore;
        fuelScore *= 1000;
        earth.color = new Color(1, 1, 1, alpha);
    }

    void FixedUpdate() // Updates 50 times per second;
    {
        if(tick < 200)
        {
            alpha += alphaRate;
            earth.color = new Color(1, 1, 1, alpha);
        }
        if(tick == 200)
            scoreText.text = "Your final score is: " + fuelScore.ToString();
        if(tick == 300)
            backButton.gameObject.SetActive(true);
        tick++;
    }

    public void mainMenu()
    {
        MusicPlayer.playMusic("main music");
        UIHandler.isOnGame = false;
        SceneManager.UnloadSceneAsync("Gameplay");
        SceneManager.UnloadSceneAsync("Gameplay UI");
        SceneManager.UnloadSceneAsync("Victory UI");
    }
}
