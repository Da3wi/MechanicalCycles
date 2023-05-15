using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambiarcosas : MonoBehaviour
{

    public GameObject puerta;




    private void OnDestroy()
    {
        puerta.SetActive(false);
    }

}
