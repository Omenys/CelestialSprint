using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadME : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SceneManager.LoadSceneAsync("Audio", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Start Menu UI", LoadSceneMode.Additive);
    }
}
