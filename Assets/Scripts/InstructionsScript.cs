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
                instructionsText.text = "Your goal is to travel through space on a ship moving through portals to arrive your desired planet";
                break;
            case 1:
                instructionsText.color = new Color(0.1862318f, 0.8773585f, 0.7152424f, 1);
                instructionsText.text = "You have to go through 20 portals to win";
                break;
            case 2:
                instructionsText.color = new Color(0.1843137f, 0.8340974f, 0.8784314f, 1);
                instructionsText.text = "There are 3 types of portals: <color=red>Red,</color> <color=blue>Blue,</color> <color=green>Green</color> Portals";
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                instructionsText.color = new Color(0.1843137f, 0.6327749f, 0.8784314f, 1);
                instructionsText.text = "Dodge the asteroids safely while traveling!";
                break;
            case 7:
                instructionsText.color = new Color(0.1843137f, 0.4252458f, 0.8784314f, 1);
                instructionsText.text = "If you get hit by an asteroids, your shield will protect you. It only has a max of 3 charges, if you lose charges you can get more on Red or Blue portals.";
                break;
        }
    }

    public void leftArrowClick()
    {
        if (index > 0)
            index--;
    }

    public void rightArrowClick()
    {
        if (index < 10)
            index++;
    }
}
