using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAudioSettings : MonoBehaviour
{
    string path;

    void Awake()
    {
        path = Application.persistentDataPath + "/audioSettings.json";
        if(File.Exists(path)) // Loading audio settings
        {
            string saveText = File.ReadAllText(path);
            SaveData myData = JsonUtility.FromJson<SaveData>(saveText);
            MusicPlayer.musicVolume = myData.musicVolume;
            SoundPlayer.sfxVolume = myData.SFXVolume;
        }
        else // If no save exists, then put the default values
        {
            MusicPlayer.musicVolume = 0.5f;
            SoundPlayer.sfxVolume = 0.5f;
        }
    }

    public void SaveAudio(float mus, float sfx)
    {
        SaveData sd = new SaveData();

        sd.musicVolume = mus;
        sd.SFXVolume = sfx;

        string jsonText = JsonUtility.ToJson(sd);
        File.WriteAllText(path, jsonText);
    }

    [System.Serializable]
    public class SaveData
    {
        public float musicVolume;
        public float SFXVolume;
    }
}
