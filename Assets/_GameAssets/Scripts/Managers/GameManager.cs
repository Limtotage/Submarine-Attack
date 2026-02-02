using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
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
    public void GameOver()
    {
        Time.timeScale = 0f;
        Debug.Log("Game Over!");
        UIManagers.Instance.GameOverScreen();
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Constants.SceneNames.LEVEL_1);
    }
}
