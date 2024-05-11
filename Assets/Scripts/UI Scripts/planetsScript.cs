using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Linq;

public class planetsScript : MonoBehaviour
{
    [SerializeField] RawImage[] planets;
    //[SerializeField] PortalEntered portalsCount;
    [SerializeField] float speed;
    float x;
    int random;
    bool canSpawn = false;
    float fill;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var planets in planets)
        {
            planets.gameObject.SetActive(false);
        }
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        fill = FindObjectOfType<progressScript>().progressBar.fillAmount;

        if (canSpawn)
        {
            rng();
            canSpawn = false;
        }
        else
        {
            planets[random].gameObject.SetActive(true);
            planets[random].color = new Color(1, 1, 1, 0.15f);
            planets[random].transform.localPosition = new Vector2(x, -94);
            if (planets[random].transform.localPosition.x > -860)
            {
                x -= speed * Time.deltaTime;
                planets[random].transform.localPosition = new Vector2(x, -94);
            }
            if (planets[random].transform.localPosition.x <= -860)
            {
                planets[random].gameObject.SetActive(false);
                canSpawn = true;
            }
        }

        if(fill >= 1)
        {
            planets[random].gameObject.SetActive(false);
            enabled = false;
        }

    }

    void rng()
    {
        random = Random.Range(0, planets.Length - 1);
        x = 750;
    }
}
