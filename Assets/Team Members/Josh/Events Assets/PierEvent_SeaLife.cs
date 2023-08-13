using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierEvent_SeaLife : MonoBehaviour
{
    [SerializeField] GameObject seaLifeParticlesObject;

    [SerializeField] float particlesSpawnDelay = 13;
    [SerializeField] float moveDuration = 1f;
    [SerializeField] float targetMoveY = 0.5f;

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

        StartCoroutine(SpawnLights());
    }

    private void Update()
    {

        if( moving && particlesLeft != null && particlesRight != null )
        {
            particlesLeft.transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
            particlesRight.transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }

    IEnumerator SpawnLights()
    {
        yield return new WaitForSeconds(particlesSpawnDelay);

        GameObject newObject = Instantiate(seaLifeParticlesObject);
        newObject.transform.position = this.transform.position + new Vector3(-2.5f, 2f, 0);
        particlesLeft = newObject;

        newObject = Instantiate(seaLifeParticlesObject);
        newObject.transform.position = this.transform.position + new Vector3(2.5f, 2f, 0);
        Vector3 rot = newObject.transform.rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y, rot.z + 180);
        newObject.transform.rotation = Quaternion.Euler(rot);
        particlesRight = newObject;

        StartCoroutine(StartStopMove(targetMoveY));
    }

    IEnumerator StartStopMove(float moveInput)
    {
        moveSpeed = (moveInput - particlesLeft.transform.position.y ) / moveDuration;
        moving = true;

        yield return new WaitForSeconds(moveDuration);

        moving = false;
        moveSpeed = 0f;
    }
}
