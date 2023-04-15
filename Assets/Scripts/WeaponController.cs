using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Transform camerePlayer;
    [SerializeField] private LayerMask hitLayers;


    [Header("Shoots parameters")]
    [SerializeField] private float fireRange = 200f;


    private void Start()
    {
        camerePlayer = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    private void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            
            if(Physics.Raycast(camerePlayer.position, camerePlayer.forward, out hit, fireRange, hitLayers))
            {
                Debug.Log("Disparo");
            }
            

        }
    }



}
