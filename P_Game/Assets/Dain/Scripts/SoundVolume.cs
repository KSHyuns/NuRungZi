using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour
{
    [SerializeField] Slider volumSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolum", 1);
            LoadPlay();
        }
    }

    public void MusicSlider()
    {

        AudioListener.volume = volumSlider.value;
        SavePlay();
    }
    public void LoadPlay()
    {
        volumSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    public void SavePlay()
    {
        PlayerPrefs.SetFloat("musicVolume", volumSlider.value);
    }
}
