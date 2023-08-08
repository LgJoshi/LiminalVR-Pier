using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleDestroy : MonoBehaviour
{
    public ParticleSystem _ps;


    // Start is called before the first frame update
    void Start()
    {
        _ps = GetComponent<ParticleSystem>();
        Destroy(); 

    }

    // Update is called once per frame
    void Destroy()
    {
        Destroy(gameObject);
    }
}
