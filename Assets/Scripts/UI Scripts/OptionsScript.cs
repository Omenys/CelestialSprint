using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsScript : MonoBehaviour
{
    public void LoadOptionsUI()
    {
        SceneManager.LoadScene("Options UI", LoadSceneMode.Additive);
        UIHandler.isOnOptions = true;
    }
}
