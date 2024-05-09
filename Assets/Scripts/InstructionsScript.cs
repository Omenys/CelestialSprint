using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionsScript : MonoBehaviour
{
    [SerializeField] TMP_Text instructionsText;
    [SerializeField] Button leftArrowButton;
    [SerializeField] Button rightArrowButton;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateInstructions()
    {
        switch (index)
        {
            case 0:
                instructionsText.color = new Color(0.1843137f, 0.8784314f, 0.5663072f, 1);
                instructionsText.text = "Your goal is to travel space on a ship moving through portals to arrive your destination planet";
                break;
            case 1:
                instructionsText.color = new Color(0.1862318f, 0.8773585f, 0.7152424f, 1);
                instructionsText.text = "You have to go through 20 portals to win";
                break;
            case 2:
                instructionsText.color = new Color(0.1843137f, 0.8340974f, 0.8784314f, 1);
                instructionsText.text = "Dodge the asteroids safely while traveling!";
                break;
            case 3:
                instructionsText.color = new Color(0.1843137f, 0.6327749f, 0.8784314f, 1);
                instructionsText.text = "If you get hit by an asteroid, your shield will protect you. It only has a max 3 charges";
                break;
            case 4:
                instructionsText.color = new Color(0.1843137f, 0.4252458f, 0.8784314f, 1);
                instructionsText.text = "If you lose charges, you can get more on some portals";
                break;
            case 5:
                instructionsText.color = new Color(0.1843137f, 0.1998195f, 0.8784314f, 1);
                instructionsText.text = "If you get hit with no shield charges, you'll get a game over :(";
                break;
            case 6:
                instructionsText.color = new Color(0.3447624f, 0.1843137f, 0.8784314f, 1);
                instructionsText.text = "There are 3 types of portals: <color=red>Red,</color> <color=blue>Blue,</color> and <color=green>Green</color>";
                break;
            case 7:
                instructionsText.color = new Color(0.4874732f, 0.1843137f, 0.8784314f, 1);
                instructionsText.text = "Going through a <color=red>Red portal</color> will <b>spawn many asteroids and 1 guaranteed <color=#00FFFF>shield charge</color>, your progression will increase by 1</b>";
                break;
            case 8:
                instructionsText.color = new Color(0.7545319f, 0.1843137f, 0.8784314f, 1);
                instructionsText.text = "Going through a <color=blue>Blue portal</color> will <b>spawn less asteroids and can rarely spawn 1 <color=#00FFFF>shield charge</color>, your progression will increase by 1</b>";
                break;
            case 9:
                instructionsText.color = new Color(0.8784314f, 0.1843137f, 0.8125698f, 1);
                instructionsText.text = "Going through a <color=green>Green portal</color> will <b>spawn faster asteroids and won't spawn any <color=#00FFFF>shield charges</color> but...</b>";
                break;
            case 10:
                instructionsText.color = new Color(0.8784314f, 0.1843137f, 0.5865815f, 1);
                instructionsText.text = "<b>...your progression will increase by 2</b>";
                break;
            case 11:
                instructionsText.color = new Color(0.8784314f, 0.1843137f, 0.3069981f, 1);
                instructionsText.text = "If you don't make it into a portal, an unavoidable cluster of asteroids will be ahead...";
                break;
            case 12:
                instructionsText.color = new Color(0.8784314f, 0.3112189f, 0.1843137f, 1);
                instructionsText.text = "...and your progression will decrease by 1";
                break;
            case 13:
                instructionsText.color = new Color(0.8784314f, 0.4871765f, 0.1843137f, 1);
                instructionsText.text = "Lastly, your ship only has a limited amount of <color=orange>fuel</color>";
                break;
            case 14:
                instructionsText.color = new Color(0.8784314f, 0.6738171f, 0.1843137f, 1);
                instructionsText.text = "It only lasts 5 minutes! Gotta go fast!";
                break;
            case 15:
                instructionsText.color = new Color(0.8784314f, 0.8212512f, 0.1843137f, 1);
                instructionsText.text = "Obvioustly running out of fuel will cause a game over";
                break;

        }
    }

    public void leftArrowClick()
    {
        if (index > 0)
            index--;
        else
            index = 15;
    }

    public void rightArrowClick()
    {
        if (index < 15)
            index++;
        else
            index = 0;
    }
}
