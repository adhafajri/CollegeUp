using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Toga : MonoBehaviour
{
    [SerializeField]
    private Transform toga;

    // Start is called before the first frame update
    void Awake()
    {
        if (GameplayController.level == 4) {
            toga.gameObject.SetActive(true);
            toga.transform.Translate(0, 0.5f, 0);
                    
            Loop();
        }
    }

    void Loop()
    {
        toga.DOLocalMoveY(1.5f, 1f)
            .SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InSine);
    }

}
