using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fuelScript : MonoBehaviour
{
    float fuelLeft = 100;
    [SerializeField] int fuelDurationInSeconds;
    float fuelDrainRate;
    [SerializeField] Image fuelBar;
    [SerializeField] Image fuelBackground;
    bool hasFuel = true;
    float x = 290;
    float y = 172;
    float randomX;
    float randomY;
    [SerializeField] float shakingPower;


    void Start()
    {
        fuelDrainRate = fuelLeft / fuelDurationInSeconds;
    }

    void Update()
    {
        drainFuel();

        if(fuelLeft > 0 && fuelLeft <= 20) // The ship has only 20% fuel left D:
        {
            randomX = Random.Range(x + shakingPower, x - shakingPower);
            randomY = Random.Range(y + shakingPower, y - shakingPower);
            fuelBar.transform.localPosition = new Vector2(randomX, randomY);
            fuelBackground.transform.localPosition = new Vector2(randomX, randomY);
        }
    }

    void noMoreFuel() // Game over :(
    {
        SceneManager.LoadSceneAsync("GameOver UI", LoadSceneMode.Additive);
        MusicPlayer.playMusic("game over");
        SceneManager.UnloadSceneAsync("Gameplay");
        SceneManager.UnloadSceneAsync("Gameplay UI");
    }

    void drainFuel()
    {
        if (fuelLeft > 0)
        {
            fuelLeft -= fuelDrainRate * Time.deltaTime;
            fuelBar.fillAmount = fuelLeft / 100;
        }
        else
        {
            if (hasFuel)
            {
                hasFuel = false;
                noMoreFuel();
            }
        }
    }
}
