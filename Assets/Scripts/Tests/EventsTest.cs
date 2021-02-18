using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsTest : MonoBehaviour
{
    public static EventsTest eventsInstance;
    //Just doing this to create a singleton

    public delegate void TestEventHandler();
    public event TestEventHandler onDebugLogMethod;

    public void Awake()
    {
        if (eventsInstance == null)
        {
            eventsInstance = this;
        }
    }
    
    public void Update()
    {

        //Above is also just for creating a singleton

        if(Input.GetKeyDown("i"))
        {
        DebugLogMethod();
        }



    }

    public void DebugLogMethod()
    {
        Debug.Log("Here is the beginning of the script, I will count to 10 then fire an event");

        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i);
        }

        Debug.Log("Now the event will fire...");
        OnDLMethodCompleted();
    }
    protected virtual void OnDLMethodCompleted()
    {
        Debug.Log("Firing now");
        onDebugLogMethod?.Invoke();
    }
}
