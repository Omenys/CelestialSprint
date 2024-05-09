using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

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


    // Start is called before the first frame update
    void Start()
    {
        resetCredits();
        sOneTitleY = sOneTitle.transform.localPosition.y;
        sOneColY = sOneLeftColumn.transform.localPosition.y;
        sTwoTitleY = sTwoTitle.transform.localPosition.y;
        sTwoColY = sTwoLeftColumn.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(sOne)
            sectionOne();
        if (sTwo)
            sectionTwo();

    }

    void resetCredits()
    {
        toggleSection(true, sectionOneParent);
        sOneTitle.transform.localPosition = new Vector2(0, -695);
        sOneLeftColumn.transform.localPosition = new Vector2(-490, -1533);
        sOneRightColumn.transform.localPosition = new Vector2(515, -1533);
        sOne = true;

        sTwoTitle.transform.localPosition = new Vector2(0, -695);
        sTwoLeftColumn.transform.localPosition = new Vector2(-597.01f, -1139.7f);
        sTwoRightColumn.transform.localPosition = new Vector2(582, -1139.7f);
        toggleSection(false, sectionTwoParent);
        sTwo = false;
    }

    void toggleSection(bool enable, GameObject section)
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
            sOneTitle.transform.localPosition = new Vector3(0, sOneTitleY);
        }
        if (sOneColY < 1200)
        {
            sOneColY += speed * Time.deltaTime;
            sOneLeftColumn.transform.localPosition = new Vector2(-490, sOneColY);
            sOneRightColumn.transform.localPosition = new Vector2(515, sOneColY);
        }
        if(sOneColY > 115)
        {
            toggleSection(true, sectionTwoParent);
            sTwo = true;
        }
        if(sOneTitleY >= 600 && sOneColY >= 1200)
        {
            toggleSection(false, sectionOneParent);
            sOne = false;
        }
    }

    void sectionTwo() // The audio!
    {
        if(sTwoTitleY < 600)
        {
            sTwoTitleY += speed * Time.deltaTime;
            sTwoTitle.transform.localPosition = new Vector3(0, sTwoTitleY);
        }
        if(sTwoColY < 1900)
        {
            sTwoColY += speed * Time.deltaTime;
            sTwoLeftColumn.transform.localPosition = new Vector3(-597.01f, sTwoColY);
            sTwoRightColumn.transform.localPosition = new Vector3(582, sTwoColY);
        }
        if(sTwoTitleY >= 600 && sTwoColY >= 1900)
        {
            toggleSection(false, sectionTwoParent);
            sTwo = false;
        }
    }    
}
