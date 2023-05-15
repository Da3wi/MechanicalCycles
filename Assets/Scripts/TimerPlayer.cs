using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.AI;

public class TimerPlayer : MonoBehaviour
{
    
    private TimeManager timemanager;
    public Volume volume;
    public NavMeshAgent enemigo;
    public NavMeshAgent enemigo2;
    public NavMeshAgent enemigo3;
    public NavMeshAgent enemigo4;
    public EnemyAI script2;
    public EnemyAI script3;
    public EnemyAI script4;
    public EnemyAI script5;
    public EnemyAI script6;



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
            volume.weight = 1;
            enemigo.enabled = false;
            script2.enabled = false;
            enemigo2.enabled = false;
            enemigo3.enabled = false;
            enemigo4.enabled = false;
            script3.enabled = false;
            script4.enabled = false;
            script5.enabled = false;
            script6.enabled = false;

        }
        if (Input.GetKeyDown(KeyCode.E) && timemanager.timeIsStopped)  //Continua el tiempo
        {
            timemanager.ContinueTime();
            volume.weight = 0;
            enemigo.enabled = true;
            script2.enabled = true;
            script2.enabled = true;
            enemigo2.enabled = true;
            enemigo3.enabled = true;
            enemigo4.enabled = true;
            script3.enabled = true;
            script4.enabled = true; 
            script5.enabled = true;
            script6.enabled = true;


        }
    }

}
