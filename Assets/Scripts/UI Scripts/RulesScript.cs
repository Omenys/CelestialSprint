using UnityEngine;
using UnityEngine.SceneManagement;

public class RulesScript : MonoBehaviour
{
    public void loadRules()
    {
        SceneManager.LoadScene("Rules UI", LoadSceneMode.Additive);
        UIHandler.isOnRules = true;
    }
}
