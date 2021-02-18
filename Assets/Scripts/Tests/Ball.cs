using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{

    private void Start()
    {
        
        EventsTest.eventsInstance.onDebugLogMethod += BallMethod;
    } 
    

    public void BallMethod()
    {
        Debug.Log("The ball has been contacted successfully");
    }
}
