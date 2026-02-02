using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        BindSlider(masterSlider, SoundManager.Instance.SetMasterVolume,SoundManager.Instance.GetVolume("MasterVolume"));
        BindSlider(musicSlider, SoundManager.Instance.SetMusicVolume,SoundManager.Instance.GetVolume("MusicVolume"));
        BindSlider(sfxSlider, SoundManager.Instance.SetSFXVolume,SoundManager.Instance.GetVolume("SFXVolume"));
    }

    void BindSlider(Slider slider, UnityEngine.Events.UnityAction<float> callback,float curVal)
    {
        slider.minValue = 0.0001f;
        slider.maxValue = 1f;
        slider.wholeNumbers = false;
        slider.value=curVal;

        slider.onValueChanged.RemoveAllListeners();
        slider.onValueChanged.AddListener(callback);

        callback(slider.value);
    }
    public void SettingsOn()
    {
        settingsPanel.SetActive(true);
    }
    public void SettingsOff()
    {
        settingsPanel.SetActive(false);
    }
    public void PlayGame()
    {
        GameManager.Instance.PlayGame();
    }
    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
