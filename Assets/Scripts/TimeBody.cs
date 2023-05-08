using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public float timeBeforAffected; //para para proyectiles
    private TimeManager timemanager;
    private Rigidbody rb;
    private Vector3 recordedVelocity;
    private float recordedMagnitude;

    private float timeBeforeAffectedTimer;
    private bool canBeAffected;
    private bool isStopped;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        timeBeforeAffectedTimer = timeBeforAffected;
    }


    void Update()
    {
        timeBeforeAffectedTimer -= Time.deltaTime; // menos 1 segundo x segundo
        if(timeBeforeAffectedTimer <= 0f)
        {
            canBeAffected = true; // es afectado por la mecanica
        }

        if(canBeAffected && timemanager.timeIsStopped && !isStopped)
        {
            if(rb.velocity.magnitude >= 0f) // por si el enemigo se mueve
            {
                recordedVelocity = rb.velocity.normalized; //registro de la direccionde  movimiento
                recordedMagnitude = rb.velocity.magnitude;//registro de la magnitud del movimiento

                rb.velocity = Vector3.zero; // para que no se mueva más
                rb.isKinematic = true; // no es afectado por la fuerza
                isStopped = true; // para que no se loopee
            }
        }
    }

    public void ContinueTime()
    {
        rb.isKinematic = false;
        isStopped = false;
        rb.velocity = recordedVelocity * recordedMagnitude; // vuelve a su velocidad normal
    }


}
