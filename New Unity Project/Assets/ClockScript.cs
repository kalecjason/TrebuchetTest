using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ClockScript : MonoBehaviour
{
    public TimeSource timeSource;
    public UnityEvent minutePassHourEvent;
    public GameObject hourHand;
    public GameObject minuteHand;
    public GameObject secondHand;
    public GameObject hourHandCube;
    public GameObject minuteHandCube;
    public GameObject secondHandCube;
    public bool eventFlag;
    public DateTime systemTime;
    // Start is called before the first frame update
    void Start()
    {
        systemTime = DateTime.Now;
        eventFlag = false;
        minutePassHourEvent.AddListener(logMinutePassHour);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSource.systemTime)
        {
            systemTime = DateTime.Now;
            secondHand.transform.eulerAngles = new Vector3(0.0f, 0.0f, ((360.0f / 60.0f) * systemTime.Second) * -1.0f);
            minuteHand.transform.eulerAngles = new Vector3(0.0f, 0.0f, ((360.0f / 60.0f) * systemTime.Minute) * -1.0f);
            hourHand.transform.eulerAngles = new Vector3(0.0f, 0.0f, ((360.0f / 12.0f) * systemTime.Hour) * -1.0f);
        }
        else if(timeSource.elapsedTime)
        {
            TimeSpan elapsed = DateTime.Now - systemTime;
            secondHand.transform.eulerAngles = new Vector3(0.0f, 0.0f, ((360.0f / 60.0f) * elapsed.Seconds) * -1.0f);
            minuteHand.transform.eulerAngles = new Vector3(0.0f, 0.0f, ((360.0f / 60.0f) * elapsed.Minutes) * -1.0f);
            hourHand.transform.eulerAngles = new Vector3(0.0f, 0.0f, ((360.0f / 12.0f) * elapsed.Hours) * -1.0f);
        }
        else
        {
            secondHand.transform.eulerAngles = new Vector3(0.0f, 0.0f, ((360.0f / 60.0f) * timeSource.second) * -1.0f);
            minuteHand.transform.eulerAngles = new Vector3(0.0f, 0.0f, ((360.0f / 60.0f) * timeSource.minute) * -1.0f);
            hourHand.transform.eulerAngles = new Vector3(0.0f, 0.0f, ((360.0f / 12.0f) * timeSource.hour) * -1.0f);
        }
        
       
        if(Math.Round(hourHand.transform.eulerAngles.z) == Math.Round(secondHand.transform.eulerAngles.z))
        {
            eventFlag = true;
        }
        else if((hourHand.transform.eulerAngles.z != secondHand.transform.eulerAngles.z) && eventFlag)
        {
            eventFlag = false;
            minutePassHourEvent.Invoke(); 
        }
    }

    void logMinutePassHour()
    {
        Debug.Log("The Minute Hand has Passed the Hour hand");
    }
}
