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
    [SerializeField] PortalEntered portalsCount;
    int uiPortalsCount = 0;
    int temp = 0;
    bool spawn = false;
    float speed = 8;
    float x;
    int random;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var planets in planets)
        {
            planets.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.rKey.wasPressedThisFrame)
        {
            uiPortalsCount++;
        }

        if (uiPortalsCount != temp)
        {
            temp = uiPortalsCount;
            random = Random.Range(0, planets.Length - 1);
            planets[random].gameObject.SetActive(true);
            x = 40;
            spawn = true;
        }

        if(spawn)
        {
            planets[random].gameObject.SetActive(true);
            planets[random].color = new Color(1, 1, 1, 0.2f);
            planets[random].transform.localPosition = new Vector2(40, -94);
            if (planets[random].transform.localPosition.x > -80)
            {
                x -= speed * Time.deltaTime;
                planets[random].transform.localPosition = new Vector2(x, -94);
            }
        }
    }
}
