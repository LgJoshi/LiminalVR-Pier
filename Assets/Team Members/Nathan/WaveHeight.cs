using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHeight : MonoBehaviour
{
    public Material waterMat;
    public float height = 0.2f;
    public float increaseHeightRate = 0.1f;
    public float stopHeight;
    public bool increase = false;

    // Start is called before the first frame update
    void Start()
    {
        
        waterMat.SetFloat("_WaveHeight", height);

        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("increaseHeight", 12);

      
        if (increase == true)
        {
            Invoke("decrease", 20);
        }


    }
    void decrease()
    {
        height -= increaseHeightRate * Time.deltaTime;
        waterMat.SetFloat("_WaveHeight", height);
        increaseHeightRate = 0.1f;
        stopHeight = 0.2f;
        if (height <= stopHeight)
        {
            height = stopHeight;
            increaseHeightRate = 0f;
        }
    }
    void increaseHeight()
    {
        if (increase == false)
        {
            height += increaseHeightRate * Time.deltaTime;
            waterMat.SetFloat("_WaveHeight", height);



            if (height >= stopHeight)
            {
                height = stopHeight;
                increaseHeightRate = 0f;

                increase = true;
            }

        }
        
    }

    }
   




