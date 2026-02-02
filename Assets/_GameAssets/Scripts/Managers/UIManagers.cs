using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagers : MonoBehaviour
{
    public static UIManagers Instance;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _SettingsPanel;
    [SerializeField] private GameObject ThanksForPlaying;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    private void OnEnable()
    {
        BindSlider(masterSlider, SoundManager.Instance.SetMasterVolume, SoundManager.Instance.GetVolume("MasterVolume"));
        BindSlider(musicSlider, SoundManager.Instance.SetMusicVolume, SoundManager.Instance.GetVolume("MusicVolume"));
        BindSlider(sfxSlider, SoundManager.Instance.SetSFXVolume, SoundManager.Instance.GetVolume("SFXVolume"));
    }

    void BindSlider(Slider slider, UnityEngine.Events.UnityAction<float> callback, float curVal)
    {
        slider.minValue = 0.0001f;
        slider.maxValue = 1f;
        slider.wholeNumbers = false;

        slider.onValueChanged.RemoveAllListeners();
        slider.SetValueWithoutNotify(curVal); 
        slider.onValueChanged.AddListener(callback);
    }

    private int _score = 0;
    private int _health = 3;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _healthText.text = "Health: " + _health;
        _scoreText.text = "Score: " + _score;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            _SettingsPanel.SetActive(true);
        }
    }
    public void SettingsOff()
    {
        Time.timeScale = 1;
        _SettingsPanel.SetActive(false);
    }
    public void UIUpdate()
    {
        _healthText.text = "Health: " + _health;
        _scoreText.text = "Score: " + _score;
    }
    public void AddScore(int Score)
    {
        _score += Score;
        UIUpdate();
    }
    public void Heal(int Heal)
    {
        _health += Heal;
        UIUpdate();
    }
    public void TakeDamage(int Damage)
    {
        _health -= Damage;
        UIUpdate();
    }
    public void GameOverScreen()
    {
        _gameOverScreen.SetActive(true);
    }
    public void ThanksForPlay()
    {
        ThanksForPlaying.SetActive(true);

    }
    public void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(Constants.SceneNames.MAIN_MENU);
    }
}
