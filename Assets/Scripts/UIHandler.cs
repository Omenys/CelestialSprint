using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text titleText;
    [SerializeField] Button gameButton;
    [SerializeField] Button creditsButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button rulesButton;

    public static bool isOnGame = false;
    public static bool isOnCredits = false;
    public static bool isOnOptions = false;
    public static bool isOnRules = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGame && !isOnCredits && !isOnOptions && !isOnRules) // clicked on Start Game
        {
            hideAll();
        }
        else if (!isOnGame && isOnCredits && !isOnOptions && !isOnRules) // clicked on Credits
        {
            hideAll();
        }
        else if(!isOnGame && !isOnCredits && isOnOptions && !isOnRules) // clicked on Options
        {
            gameButton.gameObject.SetActive(false);
            creditsButton.gameObject.SetActive(false);
            optionsButton.gameObject.SetActive(false);
            rulesButton.gameObject.SetActive(false);
        }
        else if(!isOnGame && !isOnCredits && !isOnOptions && isOnRules) // clicked on How to play
        {
            gameButton.gameObject.SetActive(false);
            creditsButton.gameObject.SetActive(false);
            optionsButton.gameObject.SetActive(false);
            rulesButton.gameObject.SetActive(false);
        }
        else
        {
            showAll();
        }
    }

    void showAll()
    {
        titleText.gameObject.SetActive(true);
        gameButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        rulesButton.gameObject.SetActive(true);
    }

    void hideAll()
    {
        titleText.gameObject.SetActive(false);
        gameButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        rulesButton.gameObject.SetActive(false);
    }
}
