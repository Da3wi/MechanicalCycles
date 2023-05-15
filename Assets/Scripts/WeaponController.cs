using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootType
{
    Manual,
    Automatic
}
public class WeaponController : MonoBehaviour
{

    [Header("Reference")]
    public Transform weaponMazzle;
    private Quaternion originalRotation;



    [Header("General")]
    [SerializeField] private Transform camerePlayer;
    [SerializeField] private LayerMask hitLayers;
    
    public GameObject owner { set; get; }


    [Header("Shoots parameters")]
    public ShootType shotType;
    [SerializeField] private float fireRange = 200f;
    public float fireRate = 0.1f;
    public int maxAmmo = 25;
    private float lasTimeShoot = Mathf.NegativeInfinity;
    public float recoilForce = 3f;

    public int currentAmmo { get; private set; }

    [Header("Reload parameters")]
    public float reloadTime = 1.5f;

    [Header("Sound y Visual")]
    public GameObject flashEffect;



    private void Awake()
    {
        currentAmmo = maxAmmo;
        EventsManager.current.updateBulletsEvent.Invoke(currentAmmo, maxAmmo);
    }
     void Start()
    {
        originalRotation = transform.localRotation;
        camerePlayer = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
     void Update()
    {
        Debug.DrawRay(camerePlayer.position, camerePlayer.forward * fireRange, Color.green);
        if (shotType == ShootType.Manual)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                TryShoot();

            }
        }
        else if(shotType == ShootType.Automatic)
        {
            if (Input.GetButton("Fire1"))
            {

                TryShoot();

            }
        }

    
        
        if (Input.GetKeyDown(KeyCode.R))
        {

            StartCoroutine(reload());

        }



        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, Time.deltaTime * 1f);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, originalRotation, Time.deltaTime * 1f);
    }



    private bool TryShoot()
    {
         if (Time.time > lasTimeShoot + fireRate)
            {
            if (currentAmmo >= 1)
            {
                HandleShoot();
                currentAmmo -= 1;
                EventsManager.current.updateBulletsEvent.Invoke(currentAmmo, maxAmmo);
                return true;
            }
        }

        return false;
    }

    private void HandleShoot()
    {

        GameObject flashcone = Instantiate(flashEffect, weaponMazzle.position, Quaternion.Euler(weaponMazzle.forward), transform);
        Destroy(flashcone, 1f);

        AddRecoil();

        
        RaycastHit hit;
        if (Physics.Raycast(camerePlayer.position,camerePlayer.forward,out hit, fireRange, hitLayers))
        {
            if (hit.collider.CompareTag("Enemigo"))
            {
                Destroy(hit.collider.gameObject);
            }
        }

      
            
               
        
        lasTimeShoot = Time.time;
    }


    public void AddRecoil()
    {
        transform.Rotate(-recoilForce,0f,0f);
        transform.position = transform.position - transform.forward * (recoilForce / 50f);
    }

    IEnumerator reload()
    {
        // empezar la animacion 
        Debug.Log("Recargadando...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        EventsManager.current.updateBulletsEvent.Invoke(currentAmmo, maxAmmo);
        Debug.Log("Recargada");

        // termina al animacion
    }


}
