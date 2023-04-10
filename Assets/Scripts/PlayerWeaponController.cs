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

    private WeaponController[] weaponSlots = new WeaponController[4]; //Inventario de armas


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
            SwitchWeapon(0);
        }
    }

    private void SwitchWeapon(int p_WeaponIndex) // Cambiar armas
    {
        if(p_WeaponIndex != activeweaponIndex && p_WeaponIndex >= 0)
        {
            weaponSlots[p_WeaponIndex].gameObject.SetActive(true); // activa el objeto
            activeweaponIndex = p_WeaponIndex;
        }
    }


    public void AddWeapon(WeaponController p_weaponPrefab) // Añadir armas
    {
        weaponParentSocket.position = defaultWeaponSocket.position;

      for (int i = 0; i<weaponSlots.Length; i++) // recorrer inventario comprobar si hay armas
        {
            if (weaponSlots[i] == null)
            {
                WeaponController weaponclone = Instantiate(p_weaponPrefab, weaponParentSocket); // pone el arma en falso se activa poniendo slots
                weaponclone.gameObject.SetActive(false);

                weaponSlots[i] = weaponclone;

                return; // retorna si para no bugear
            }
        }
    }

}
