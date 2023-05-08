using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPlayer : MonoBehaviour
{
    private TimeManager timemanager;
    
   
    void Start()
    {
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //detiene el tiempo
        {
            timemanager.StopTime();
            
        }
        if (Input.GetKeyDown(KeyCode.E) && timemanager.timeIsStopped)  //Continua el tiempo
        {
            timemanager.ContinueTime();
            

        }
    }

}
