using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fall : MonoBehaviour
{
    void Start()
    {
    }

    void InvokeFalling()
    {
        gameObject.AddComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Player")
        {
            Invoke("InvokeFalling", 0.5f);
        }
    }
}
