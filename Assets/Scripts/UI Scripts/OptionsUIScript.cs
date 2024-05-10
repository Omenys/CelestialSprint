using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class OptionsUIScript : MonoBehaviour
{
    // Once this branch is loaded into the main one, access the volume variables.

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    int randomSFX;
    int tick;
    
    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = MusicPlayer.musicVolume;
        SFXSlider.value = SoundPlayer.sfxVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if (!musicSlider.interactable)
            musicSlider.value = MusicPlayer.musicVolume;
        else
            MusicPlayer.musicVolume = musicSlider.value;

        if (!SFXSlider.interactable)
            SFXSlider.value = SoundPlayer.sfxVolume;
        else
            SoundPlayer.sfxVolume = SFXSlider.value;

        if (Mouse.current.leftButton.wasReleasedThisFrame)
            if (EventSystem.current.currentSelectedGameObject?.name == "SFX Volume Slider")
                playRandomSFX();
    }

    private void FixedUpdate()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {

        }

    }

    public void UnloadOptionsUI()
    {
        UIHandler.isOnOptions = false;
        SceneManager.UnloadSceneAsync("Options UI");
    }

    public void OnMusicSlider(InputValue value)
    {
        if (value.Get<float>() != 0)
            musicSlider.interactable = false;
        else
            musicSlider.interactable = true;
    }

    public void OnSFXSlider(InputValue value)
    {
        if(value.Get<float>() != 0)
            SFXSlider.interactable = false;
        else
        {
            SFXSlider.interactable = true;
            playRandomSFX();
        }
    }

    protected void playRandomSFX()
    {
        randomSFX = Random.Range(0, 2);

        switch (randomSFX)
        {
            case 0:
                SoundPlayer.playSound("teleport 1");
                break;
            case 1:
                SoundPlayer.playSound("teleport 2");
                break;
            case 2:
                SoundPlayer.playSound("teleport 3");
                break;
        }
    }

}
