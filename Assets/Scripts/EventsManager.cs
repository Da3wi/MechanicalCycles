using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Int2Event : UnityEvent<int, int> { }
public class EventsManager : MonoBehaviour
{
    #region Singleton

    public static EventsManager current;


    private void Awake()
    {
        if(current == null) { current = this; } else if(current != null) { Destroy(this); }
    }


    #endregion 




    public Int2Event updateBulletsEvent = new Int2Event();
    public UnityEvent NewGunEvent = new UnityEvent();
}
