using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{

    public List<WeaponController> startWeapons = new List<WeaponController>();

    [SerializeField] private Transform weaponParentSocket;
    [SerializeField] private Transform defaultWeaponSocket;
    [SerializeField] private Transform aimWeaponSocket;

    public int activeweaponIndex { get; private set; }

    private WeaponController[] weaponSlots = new WeaponController[2]; //Inventario de armas


    private void Start()
    {
        activeweaponIndex = -1;

        foreach (WeaponController startWeapon in startWeapons)
        {
            AddWeapon(startWeapon);
        }

       
       

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // primera arma
        {
            SwitchWeapon();
        }
    }

    private void SwitchWeapon() // Cambiar armas
    {
        int tempIndex = (activeweaponIndex + 1) % weaponSlots.Length;

        if (weaponSlots[tempIndex] == null)
            return;

       
        foreach(WeaponController weapon in weaponSlots)
        {
            if (weapon != null) weapon.gameObject.SetActive(false);
        }

        weaponSlots[tempIndex].gameObject.SetActive(true); // activa el objeto
        activeweaponIndex = tempIndex;

        EventsManager.current.NewGunEvent.Invoke();
    }


    public void AddWeapon(WeaponController p_weaponPrefab) // Añadir armas
    {
        weaponParentSocket.position = defaultWeaponSocket.position;

      for (int i = 0; i<weaponSlots.Length; i++) // recorrer inventario comprobar si hay armas
        {
            if (weaponSlots[i] == null)
            {
                WeaponController weaponclone = Instantiate(p_weaponPrefab, weaponParentSocket); // pone el arma en falso se activa poniendo slots
                weaponclone.owner = gameObject;
                weaponclone.gameObject.SetActive(false);

                

                weaponSlots[i] = weaponclone;

                return; // retorna si para no bugear
            }
        }
    }

}
