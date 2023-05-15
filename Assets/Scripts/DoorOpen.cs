using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour, IInteractable
{

    public GameObject door;


    public void Interac()
    {
        door.SetActive(false);
    }


}
