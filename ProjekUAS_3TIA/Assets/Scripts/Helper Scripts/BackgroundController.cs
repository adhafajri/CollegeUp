using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    [SerializeField]
    private Sprite level1, level2, level3, level4;

    void Awake()
    {
        switch (GameplayController.level)
        {
            case 1:
                GetComponent<SpriteRenderer>().sprite = level1;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = level2;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = level3;
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = level4;
                break;
        }
    }
}
