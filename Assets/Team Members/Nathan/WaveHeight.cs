using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHeight : MonoBehaviour
{
    public Material waterMat;
    public float height = 0.2f;
    public float increaseHeightRate = 0.1f;
    public float stopHeight = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        
        waterMat.SetFloat("_WaveHeight", height);
        //WaterRise();
    }

    // Update is called once per frame
    void Update()
    {
        height += increaseHeightRate * Time.deltaTime;
        waterMat.SetFloat("_WaveHeight", height);



        if ( height >= stopHeight)
        {
            height = stopHeight;
            increaseHeightRate = 0f;
        }
    }
    void WaterRise()
    {
        height += increaseHeightRate * Time.deltaTime;
        waterMat.SetFloat("_WaveHeight", height);
    }

   



}
