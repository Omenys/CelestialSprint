using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class OptionsUIScript : MonoBehaviour
{
    // Once this branch is loaded into the main one, access the volume variables.

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    float tempMusicVol;
    float tempSFXVol;
    
    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = MusicPlayer.musicVolume;
        SFXSlider.value = SoundPlayer.sfxVolume;
    }

    // Update is called once per frame
    void Update()
    {
        tempMusicVol = MusicPlayer.musicVolume;
        tempSFXVol = SoundPlayer.sfxVolume;

        if(musicSlider.value != tempMusicVol)
            MusicPlayer.musicVolume = musicSlider.value;
        if(SFXSlider.value != tempSFXVol)
            SoundPlayer.sfxVolume = SFXSlider.value;

        if (Input.GetKeyUp(KeyCode.Minus) || Input.GetKeyUp(KeyCode.Equals))
            musicSlider.interactable = true;

    }

    public void UnloadOptionsUI()
    {
        UIHandler.isOnOptions = false;
        SceneManager.UnloadSceneAsync("Options UI");
    }

    public void OnMusicSlider(InputValue value)
    {
        if (value.Get<float>() > 0)
        {
            //musicSlider.interactable = false;
            musicSlider.value = MusicPlayer.musicVolume;
        }
        else if (value.Get<float>() < 0)
        {
            //musicSlider.interactable = false;
            musicSlider.value = MusicPlayer.musicVolume;
        }
    }

}
