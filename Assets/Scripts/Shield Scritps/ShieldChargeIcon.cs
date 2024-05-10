using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.UIElements;

public class ShieldChargeIcon : MonoBehaviour
{
    [SerializeField] ShieldChargeStat stat;
    [SerializeField] GameObject[] shieldIcons;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RemoveIcon();
        AddIcon();
        if (Input.GetKeyUp(KeyCode.Space))
        {
            stat.currentShieldCount -= 1;
            RemoveIcon();
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            stat.currentShieldCount += 1;
            AddIcon();
        }
        
    }

    void RemoveIcon()
    {
        /*if (stat.currentShieldCount < shieldIcons.Length)
        {
            shieldIcons[i].SetActive(false);
        }*/

        if (stat.currentShieldCount == 2)
        {
            shieldIcons[2].SetActive(false);
        }
        if (stat.currentShieldCount == 1)
        {
            shieldIcons[1].SetActive(false);
        }
        if (stat.currentShieldCount == 0)
        {
            shieldIcons[0].SetActive(false);
        }
    }

    void AddIcon()
    {
        /*if (stat.currentShieldCount > shieldIcons.Length)
        {
            shieldIcons[i].SetActive(true);
        }*/

        
        if (stat.currentShieldCount == 1)
        {
            shieldIcons[0].SetActive(true);
        }
        if (stat.currentShieldCount == 2)
        {
            shieldIcons[1].SetActive(true);
        }
        if (stat.currentShieldCount == 3)
        {
            shieldIcons[2].SetActive(true);
        }
    }
}
