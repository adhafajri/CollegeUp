using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    
    public static GameplayController instance;
    public static int level = 1;

    [SerializeField]
    private Sprite level1, level2, level3, level4;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void IncrementLevel()
    {
        level++; 
    }

    public void Transition(string invoke)
    {
        Invoke(invoke, 3f);
    }

    public void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuGameOver");
    }

    void ReloadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void PlayGame()
    {
        level = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TryAgainGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void FinishGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuMenang");
    }

    public void MenuGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void HowToPlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuHowToPlay");
    }
}
