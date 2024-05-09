using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loadCredits()
    {
        SceneManager.LoadSceneAsync("Credits UI", LoadSceneMode.Additive);
        UIHandler.isOnCredits = true;
    }
}
