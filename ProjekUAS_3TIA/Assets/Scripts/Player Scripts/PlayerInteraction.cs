using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody rb;
    private bool playerDied;
    private CameraFollow cameraFollow;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDied)
        {
            if (rb.velocity.sqrMagnitude > 60)
            {
                cameraFollow.CanFollow = false;
                gameObject.SetActive(false);
                GameplayController.instance.Transition("GameOver");

                SoundManager.instance.BackgroundSound(false);
                SoundManager.instance.GameOverSound();
            }
        }
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Spike")
        {
            cameraFollow.CanFollow = false;
            gameObject.SetActive(false);
            GameplayController.instance.Transition("GameOver");

            SoundManager.instance.BackgroundSound(false);
            SoundManager.instance.GameOverSound();
        }

        if (target.tag == "Finish")
        {
            cameraFollow.CanFollow = false;
            PlayerMovement.move = false;
            GameplayController.instance.FinishGame();
            SoundManager.instance.BackgroundSound(false);
            SoundManager.instance.GameVictorySound();
        }
    }

    void OnCollisionEnter(Collision target)
    {
        PlayerMovement.jump = true;
        if (GameplayController.level != 4)
        {
            if (target.gameObject.tag == "EndPlatform")
            {
                GameplayController.instance.IncrementLevel();
                SoundManager.instance.GameEndSound();
                GameplayController.instance.Transition("ReloadGame");
                PlayerMovement.move = false;
            }
        }

        if (target.gameObject.tag == "StartPlatform")
        {
            
            SoundManager.instance.BackgroundSound(true);
            SoundManager.instance.GameStartSound();
            PlayerMovement.move = true;
        }
    }
}
