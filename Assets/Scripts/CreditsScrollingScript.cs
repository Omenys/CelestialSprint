using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditsScrollingScript : MonoBehaviour
{
    [SerializeField] TMP_Text sectionTitle;
    [SerializeField] TMP_Text leftColumn;
    [SerializeField] TMP_Text rightColumn;
    [SerializeField] float speed;
    float titleY;
    float colY;


    // Start is called before the first frame update
    void Start()
    {
        resetCredits();
        titleY = sectionTitle.transform.localPosition.y;
        colY = leftColumn.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(titleY < 600)
        {
            titleY += speed * Time.deltaTime;
            sectionTitle.transform.localPosition = new Vector3(0, titleY);
        }
        if(colY < 1700)
        {
            colY += speed * Time.deltaTime;
            leftColumn.transform.localPosition = new Vector2(-397.1128f, colY);
            rightColumn.transform.localPosition = new Vector2(515, colY);
        }
    }

    void resetCredits()
    {
        sectionTitle.transform.localPosition = new Vector2(0, -695);
        leftColumn.transform.localPosition = new Vector2(-425, -1059.9f);
        rightColumn.transform.localPosition = new Vector2(515, -1059.9f);
    }
}
