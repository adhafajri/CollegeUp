using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    [SerializeField]
    private AudioSource gameStart, gameOver, gameVictory, gameEnd, jumpSound, backgroundSound;



    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }


        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MainMenu")
        {
            SoundManager.instance.BackgroundSound(true);
        }
    }

    public void GameStartSound()
    {
        gameStart.Play();
    }

    public void GameEndSound()
    {
        gameEnd.Play();
    }

    public void JumpSound()
    {
        jumpSound.Play();
    }

    public void GameOverSound()
    {
        gameOver.Play();
    }

    public void GameVictorySound()
    {
        gameVictory.Play();
    }

    public void BackgroundSound(bool play)
    {
        if (play == true)
        { 
            if (!backgroundSound.isPlaying)
            {
                
                backgroundSound.Play();
            }
        }
        else
        {
            backgroundSound.Stop();
        }
    }
}
