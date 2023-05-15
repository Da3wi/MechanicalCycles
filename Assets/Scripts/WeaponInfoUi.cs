using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponInfoUi : MonoBehaviour
{
    public TextMeshProUGUI currentBullets;
    public TextMeshProUGUI totalBullets;

    private void OnEnable()
    {
        EventsManager.current.updateBulletsEvent.AddListener(UpdateBullets);
    }

    private void OnDisable()
    {
        EventsManager.current.updateBulletsEvent.RemoveListener(UpdateBullets);
    }

    public void UpdateBullets(int newCurrentBullets, int newTotalsBullets )
    {
        if (newCurrentBullets <= 0)
        {
            currentBullets.color = new Color(1, 0, 0);
        }
        else
        {
            currentBullets.color = Color.white;
        }
        currentBullets.text = newCurrentBullets.ToString();
        totalBullets.text = newTotalsBullets.ToString();
    }

   
}
