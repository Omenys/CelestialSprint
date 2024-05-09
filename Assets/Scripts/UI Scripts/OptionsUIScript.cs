using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsUIScript : MonoBehaviour
{
    // Once this branch is loaded into the main one, access the volume variables.

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Here goes the audio serialization, do this when this is merged into the main branch.


    }

    public void UnloadOptionsUI()
    {
        UIHandler.isOnOptions = false;
        SceneManager.UnloadSceneAsync("Options UI");
    }
}
