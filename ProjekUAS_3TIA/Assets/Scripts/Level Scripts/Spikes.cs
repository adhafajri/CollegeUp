using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spikes : MonoBehaviour
{

    [SerializeField]
    private Transform[] spikes;

    private bool fallDown;

    // Start is called before the first frame update
    void Start()
    {
        ActivatePlatform();
    }

    void ActivatePlatform()
    {
        int chance = Random.Range(0, 100);

        if (chance > 70)
        {
            int type = Random.Range(0, 8);

            if (type == 0 || type == 3 || type == 6)
            {
                ActivateSpike();
            }
        }
    }

    void ActivateSpike()
    {
        int index = Random.Range(0, spikes.Length);

        spikes[index].gameObject.SetActive(true);

        spikes[index].DOLocalMoveY(0.7f, 1.3f)
            .SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(0.5f, 1.5f)).SetEase(Ease.InSine);
    }


}
