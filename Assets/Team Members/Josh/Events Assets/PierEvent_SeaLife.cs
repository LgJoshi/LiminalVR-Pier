using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierEvent_SeaLife : MonoBehaviour
{
    [SerializeField] GameObject seaLifeParticlesObject;

    void Start()
    {

        GameObject newObject = Instantiate(seaLifeParticlesObject);
        newObject.transform.position = this.transform.position + new Vector3(-2.5f, 0.5f, 0);

        newObject = Instantiate(seaLifeParticlesObject);
        newObject.transform.position = this.transform.position + new Vector3(2.5f, 0.5f, 0);
        Vector3 rot = newObject.transform.rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y, rot.z + 180);
        newObject.transform.rotation = Quaternion.Euler(rot);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
