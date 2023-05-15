using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VidaEnemigo : MonoBehaviour
{
    public float life = 25;
    public PlayerController player;
    public Animator anim;








    public void Dead(int damage)
    {
        life -= damage;
        if (life >= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.enabled = false;
            anim.Play("DEAD");
        }

    }
}
