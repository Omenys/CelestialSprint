using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class OptionsUIScript : MonoBehaviour
{
    // Once this branch is loaded into the main one, access the volume variables.

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    float musicVol;
    float tempMus;
    float tempSFXVol;
    bool changingMusicWithKey = false;
    
    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = MusicPlayer.musicVolume;
        SFXSlider.value = SoundPlayer.sfxVolume;
        musicVol = MusicPlayer.musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if(musicSlider.interactable == false)
        {
            musicVol = MusicPlayer.musicVolume;
            musicSlider.value = musicVol;
        }
        else
            if (musicSlider.value != MusicPlayer.musicVolume)
                MusicPlayer.musicVolume = musicSlider.value;
            


        //if (!Mouse.current.leftButton.isPressed && (!Keyboard.current.minusKey.isPressed || !Keyboard.current.equalsKey.isPressed))
            //if(musicSlider.value != MusicPlayer.musicVolume)
                //MusicPlayer.musicVolume = musicSlider.value;
            

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
            musicSlider.interactable = false;
        else if (value.Get<float>() < 0)
            musicSlider.interactable = false;
    }

}
