using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleDestroy : MonoBehaviour
{
    public ParticleSystem _ps;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_ps, transform.position, transform.rotation);
        //Destroy(); 

    }

    // Update is called once per frame
    void Destroy()
    {
        Destroy(gameObject);
    }
}
