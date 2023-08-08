using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPierEvent_SeaLife : MonoBehaviour
{
    [SerializeField] GameObject seaLifeParticlesObject;

    [SerializeField] float particlesSpawnDelay = 5;
    bool timerOn = false;
    float timer = 0f;
    float timerMax = 0f;

    int sequenceNum = 0;
    bool moving = false;
    float moveSpeed = 0;
    float moveTargetY = 0f;

    GameObject particlesLeft;
    GameObject particlesRight;

    void Start()
    {
        sequenceNum = 0;
        moving = false;
        moveSpeed = 0;
        moveTargetY = 0f;

        timerMax = particlesSpawnDelay;
        timer = 0f;
        timerOn = true;
    }

    private void Update()
    {
        if( timerOn )
        {
            timer -= Time.deltaTime;
            if( timer <= 0 )
            {
                timerOn = false;
                TriggerSequence();
            }
        }

        if( moving && particlesLeft != null )
        {
            particlesLeft.transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }

        if( moving && particlesRight != null )
        {
            particlesRight.transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }

    void TriggerSequence()
    {
        sequenceNum++;

        switch( sequenceNum )
        {
            case 0:
            Debug.Log("uh oh nothing");
            break;

            case 1:
            moving = true;
            moveSpeed = -0.1f;
            moveTargetY = -0.5f;
            break;

            case 2:
            moving = true;
            moveSpeed = 0.1f;
            break;

        }
    }

    void SpawnLights()
    {
        GameObject newObject = Instantiate(seaLifeParticlesObject);
        newObject.transform.position = this.transform.position + new Vector3(-2.5f, 0.5f, 0);
        particlesLeft = newObject;

        newObject = Instantiate(seaLifeParticlesObject);
        newObject.transform.position = this.transform.position + new Vector3(2.5f, 0.5f, 0);
        Vector3 rot = newObject.transform.rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y, rot.z + 180);
        newObject.transform.rotation = Quaternion.Euler(rot);
        particlesRight = newObject;
    }
}
