using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public void loadCredits()
    {
        SceneManager.LoadSceneAsync("Credits UI", LoadSceneMode.Additive);
        UIHandler.isOnCredits = true;
        MusicPlayer.playMusic("credits");
    }
}
