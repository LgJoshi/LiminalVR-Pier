using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] PlayableDirector myDirector;

    float delayInitial = 5f;
    //float delayBetween = 3f;

    float timer = 0f;
    bool timerActive = false;
    int eventInt = -1;

    [SerializeField] GameObject IntroObject;
    [SerializeField] GameObject[] eventObjects;
    [SerializeField] GameObject OutroObject;

    [SerializeField] GameObject VRAvatar;
    [SerializeField] GameObject Environment;

    float introDelay = 4f;
    float betweenDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //StartTimeline();
        timer = 0f;

        StartCoroutine(StartEvents());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if( timerActive )
        {
            timer -= Time.deltaTime;
            if( timer <= 0 )
            {
                timerActive = false;
                Debug.Log("timer 0, now run next event couroutine");
                
            }
        }*/
    }

    private void StartTimeline()
    {
        //myDirector.Play();
    }

    IEnumerator StartEvents()
    {
        yield return new WaitForSeconds(introDelay);

        GameObject newEvent = IntroObject;
        newEvent.SetActive(true);
        timer = newEvent.GetComponent<PierEvent>().myDuration;

        StartCoroutine(NextEvent(newEvent.GetComponent<PierEvent>().myDuration));
        /*if( newEvent.GetComponent<PierEvent>().isFollowingPlayer )
        {
            newEvent.transform.parent = VRAvatar.transform;
        } else
        {
            newEvent.transform.parent = Environment.transform;
        }*/
    }

    IEnumerator NextEvent(float inputDuration)
    {
        yield return new WaitForSeconds(inputDuration);
        yield return new WaitForSeconds(betweenDelay);

        eventInt += 1;
        if( eventInt < eventObjects.Length )
        {
            GameObject newEvent = eventObjects[eventInt];
            newEvent.SetActive(true);
            newEvent.transform.position = this.transform.position;
            Debug.Log("new event in array:" + newEvent.name);

            StartCoroutine(NextEvent(newEvent.GetComponent<PierEvent>().myDuration));
            /*if( newEvent.GetComponent<PierEvent>().isFollowingPlayer )
            {
                newEvent.transform.parent = VRAvatar.transform;
            } else
            {
                newEvent.transform.parent = Environment.transform;
            }*/
        } else
        {

            OutroObject.SetActive(true);
        }
    }
}
