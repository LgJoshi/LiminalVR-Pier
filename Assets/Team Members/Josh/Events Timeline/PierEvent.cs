using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierEvent : MonoBehaviour
{
    public float myDuration;
    public bool isFollowingPlayer = true;

    float timer = 0f;

    void Start()
    {
        timer = 0f;

    }

    /*
    void Update()
    {
        timer += Time.deltaTime;
        if( timer >= myDuration + 4 )
        {
            Destroy(this);
        }
    }
    */
}
