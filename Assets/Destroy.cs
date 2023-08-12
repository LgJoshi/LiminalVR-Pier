using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public ParticleSystem starsPS;



    // Start is called before the first frame update
    void Start()
    {
        Instantiate(starsPS, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
