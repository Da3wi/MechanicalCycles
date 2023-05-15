using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerHud : MonoBehaviour
{

    public GameObject weaponInfoPrefab;



    private void Start()
    {
        EventsManager.current.NewGunEvent.AddListener(createWeaponInfo);
    }
  



    public void createWeaponInfo()
    {
        Instantiate(weaponInfoPrefab, transform);
    }
}
