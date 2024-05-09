using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class CreditsScrollingScript : MonoBehaviour
{
    [SerializeField] float speed;

    // Section 1 stuff
    [SerializeField] GameObject sectionOneParent;
    [SerializeField] TMP_Text sOneTitle;
    [SerializeField] TMP_Text sOneLeftColumn;
    [SerializeField] TMP_Text sOneRightColumn;
    float sOneTitleY;
    float sOneColY;
    bool sOne;

    // Section 2 stuff
    [SerializeField] GameObject sectionTwoParent;
    [SerializeField] TMP_Text sTwoTitle;
    [SerializeField] TMP_Text sTwoLeftColumn;
    [SerializeField] TMP_Text sTwoRightColumn;
    float sTwoTitleY;
    float sTwoColY;
    bool sTwo;

    // Section 3 stuff
    [SerializeField] GameObject sectionThreeParent;
    [SerializeField] TMP_Text sThreeTitle;
    [SerializeField] TMP_Text sThreeLeftColumn;
    [SerializeField] TMP_Text sThreeRightColumn;
    float sThreeTitleY;
    float sThreeColY;
    bool sThree;


    // Start is called before the first frame update
    void Start()
    {
        resetCredits();
    }

    // Update is called once per frame
    void Update()
    {
        if(sOne)
            sectionOne();
        if (sTwo)
            sectionTwo();
        if (sThree)
            sectionThree();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MusicPlayer.playMusic("main music");
            UIHandler.isOnCredits = false;
            SceneManager.UnloadSceneAsync("Credits UI");
        }
    }

    void resetCredits()
    {
        // Section 1
        toggleSection(sectionOneParent, true);
        sOneTitleY = sOneTitle.transform.localPosition.y;
        sOneColY = sOneLeftColumn.transform.localPosition.y;
        sOneTitle.transform.localPosition = new Vector2(0, -695);
        sOneLeftColumn.transform.localPosition = new Vector2(-490, -1533);
        sOneRightColumn.transform.localPosition = new Vector2(515, -1533);
        sOne = true;

        // Section 2
        sTwoTitleY = sTwoTitle.transform.localPosition.y;
        sTwoColY = sTwoLeftColumn.transform.localPosition.y;
        sTwoTitle.transform.localPosition = new Vector2(0, -695);
        sTwoLeftColumn.transform.localPosition = new Vector2(-597.01f, -1139.7f);
        sTwoRightColumn.transform.localPosition = new Vector2(582, -1139.7f);
        toggleSection(sectionTwoParent, false);
        sTwo = false;

        // Section 3
        sThreeTitleY = sThreeTitle.transform.localPosition.y;
        sThreeColY = sThreeLeftColumn.transform.localPosition.y;
        sThreeTitle.transform.localPosition = new Vector2(0, -695);
        sThreeLeftColumn.transform.localPosition = new Vector2(-597.01f, -882.35f);
        sThreeRightColumn.transform.localPosition = new Vector2(621.446f, -882.35f);
        toggleSection(sectionThreeParent, false);
        sThree = false;
    }

    void toggleSection(GameObject section, bool enable)
    {
        if(enable)
        {
            section.SetActive(true);
        }
        else if(!enable)
        {
            section.SetActive(false);
        }
    }

    void sectionOne() // The team!
    {
        if (sOneTitleY < 600)
        {
            sOneTitleY += speed * Time.deltaTime;
            sOneTitle.transform.localPosition = new Vector2(0, sOneTitleY);
        }
        if (sOneColY < 1200)
        {
            sOneColY += speed * Time.deltaTime;
            sOneLeftColumn.transform.localPosition = new Vector2(-490, sOneColY);
            sOneRightColumn.transform.localPosition = new Vector2(515, sOneColY);
        }
        if(sOneColY > 115)
        {
            toggleSection(sectionTwoParent, true);
            sTwo = true;
        }
        if(sOneColY >= 1200)
        {
            toggleSection(sectionOneParent, false);
            sOne = false;
        }
    }

    void sectionTwo() // The audio!
    {
        if(sTwoTitleY < 600)
        {
            sTwoTitleY += speed * Time.deltaTime;
            sTwoTitle.transform.localPosition = new Vector2(0, sTwoTitleY);
        }
        if(sTwoColY < 1900)
        {
            sTwoColY += speed * Time.deltaTime;
            sTwoLeftColumn.transform.localPosition = new Vector2(-597.01f, sTwoColY);
            sTwoRightColumn.transform.localPosition = new Vector2(582, sTwoColY);
        }
        if(sTwoColY > 925)
        {
            toggleSection(sectionThreeParent, true);
            sThree = true;
        }
        if(sTwoColY >= 1900)
        {
            toggleSection(sectionTwoParent, false);
            sTwo = false;
        }
    }

    void sectionThree() // The art!
    {
        if(sThreeTitleY < 600)
        {
            sThreeTitleY += speed * Time.deltaTime;
            sThreeTitle.transform.localPosition = new Vector2(0, sThreeTitleY);
        }
        if(sThreeColY < 700)
        {
            sThreeColY += speed * Time.deltaTime;
            sThreeLeftColumn.transform.localPosition = new Vector2(-597.01f, sThreeColY);
            sThreeRightColumn.transform.localPosition = new Vector2(621.446f, sThreeColY);
        }
        if(sThreeColY >= 700)
        {
            resetCredits();
        }
    }
}
