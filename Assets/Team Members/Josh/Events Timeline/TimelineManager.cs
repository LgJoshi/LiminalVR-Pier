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

    // Start is called before the first frame update
    void Start()
    {
        //StartTimeline();
        timer = 0f;

        StartEvents();
    }

    // Update is called once per frame
    void Update()
    {
        if( timerActive )
        {
            timer -= Time.deltaTime;
            if( timer <= 0 )
            {
                timerActive = false;
                NextEvent();
            }
        }
    }

    private void StartTimeline()
    {
        //myDirector.Play();
    }

    private void StartEvents()
    {
        GameObject newEvent = Instantiate(IntroObject);
        timer = newEvent.GetComponent<PierEvent>().myDuration;
        timerActive = true;
    }

    private void NextEvent()
    {
        eventInt += 1;
        if( eventInt >= eventObjects.Length )
        {
            GameObject newEvent = Instantiate(eventObjects[eventInt]);
            timer = newEvent.GetComponent<PierEvent>().myDuration;
            timerActive = true;
        } else
        {
            GameObject newEvent = Instantiate(OutroObject);
        }
    }
}
