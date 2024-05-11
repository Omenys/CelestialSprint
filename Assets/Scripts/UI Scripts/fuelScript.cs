using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class fuelScript : MonoBehaviour
{
    public float fuelLeft = 100;
    [SerializeField] int fuelDurationInSeconds;
    float fuelDrainRate;
    [SerializeField] Image fuelBar;
    [SerializeField] Image fuelBackground;
    [SerializeField] Color[] fuelColors;
    [SerializeField] int lowFuelPercentageNum;
    [SerializeField] int criticalFuelPercentageNum;
    float timer = 0;
    bool startedBlinking = false;
    bool switchColor = true;
    [SerializeField] float blinkingInterval;
    bool hasFuel = true;
    float x = 290;
    float y = 172;
    float randomX;
    float randomY;
    [SerializeField] float shakingPower;
    [SerializeField] float criticalShakingPower;
    //[SerializeField] PortalEntered portalsCount;
    int uiPortalsCount = 0;
    bool hasWon = false;
    int tick = 0;
    float alpha = 1.0f;


    void Start()
    {
        fuelBar.color = fuelColors[0];
        fuelDrainRate = fuelLeft / fuelDurationInSeconds;
    }

    void Update()
    {
        //uiPortalsCount = portalsCount.portalsEntered;

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Debug.Log("hi");
            uiPortalsCount++;
        }

        if (uiPortalsCount < 10) // Game lasts 10 portals
        {
            drainFuel();

            if (fuelLeft > criticalFuelPercentageNum && fuelLeft <= lowFuelPercentageNum) // The ship has low fuel D:
            {
                shakingAnim();
            }
            else if (fuelLeft > 0 && fuelLeft <= criticalFuelPercentageNum) // CRITICAL FUEL NOOOOOOOOOO
            {
                criticalShakingAnim();
                lowFuelBlinking();
            }
        }
        else
        {
            hasWon = true;
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

    void shakingAnim()
    {
        randomX = Random.Range(x + shakingPower, x - shakingPower);
        randomY = Random.Range(y + shakingPower, y - shakingPower);
        fuelBar.transform.localPosition = new Vector2(randomX, randomY);
        fuelBackground.transform.localPosition = new Vector2(randomX, randomY);
    }

    void criticalShakingAnim()
    {
        randomX = Random.Range(x + criticalShakingPower, x - criticalShakingPower);
        randomY = Random.Range(y + criticalShakingPower, y - criticalShakingPower);
        fuelBar.transform.localPosition = new Vector2(randomX, randomY);
        fuelBackground.transform.localPosition = new Vector2(randomX, randomY);
    }

    void lowFuelBlinking()
    {
        if(!startedBlinking)
        {
            startedBlinking = true;
            fuelBar.color = fuelColors[1];
        }

        timer += Time.deltaTime;

        if (timer > blinkingInterval)
        {
            timer = 0;
            if(!switchColor)
            {
                switchColor = true;
                fuelBar.color = fuelColors[0];
            }
            else
            {
                switchColor = false;
                fuelBar.color = fuelColors[1];
            }
        }
    }

    private void FixedUpdate() // Updates 50 times per second
    {
        if (hasWon)
        {
            if (tick > 75 && alpha > 0)
            {
                fuelBar.color = new Color(fuelColors[0].r, fuelColors[0].g, fuelColors[0].b, alpha);
                fuelBackground.color = new Color(fuelColors[2].r, fuelColors[2].g, fuelColors[2].b, alpha);
                alpha -= 0.005f;
            }
            tick++;
        }
    }
}
