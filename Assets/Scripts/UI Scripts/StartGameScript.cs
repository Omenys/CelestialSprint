using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public void startTheGame()
    {
        SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Gameplay UI", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Hazards", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Portals", LoadSceneMode.Additive);
        UIHandler.isOnGame = true;
    }
}
