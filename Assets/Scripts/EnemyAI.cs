using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 10f; // rango de detecci�n del jugador
    public LayerMask playerLayer; // capa del jugador
    public Transform target; // transform del jugador
    public float speed;
    public GameObject panelDed;
    private bool isFollowing = false; // indica si el enemigo est� persiguiendo al jugador
    private float followTime = 0f; // indica cu�nto tiempo ha estado persiguiendo al jugador
    public Animator animator;
    public AudioClip spiderSound;
    public AudioSource audioSource;
    private void Update()
    {
        // comprueba si hay alg�n objeto entre el enemigo y el jugador
        Vector3 direction = target.position - transform.position;
        bool isObstructed = Physics.Linecast(transform.position, target.position, out RaycastHit hit, ~playerLayer);

        if (!isObstructed && direction.magnitude <= detectionRange)
        {
            // si no hay obst�culos y el jugador est� dentro del rango de detecci�n, persigue al jugador
            //Debug.DrawRay(transform.position, direction, Color.green); // muestra el rayo en el editor
            Debug.DrawRay(transform.position, transform.forward * detectionRange, Color.yellow); // muestra el rango de visi�n del enemigo
            // aqu� puedes a�adir c�digo para perseguir al jugador, por ejemplo:
            audioSource.PlayOneShot(spiderSound);
            transform.LookAt(target); // mira al jugador
            transform.Translate(Vector3.forward * speed * Time.deltaTime); // avanza hacia el jugador
            isFollowing = true; // el enemigo est� persiguiendo al jugador
            followTime += Time.deltaTime; // aumenta el tiempo de seguimiento
        }
        else
        {
            // si hay obst�culos o el jugador est� fuera del rango de detecci�n, no hace nada
            //Debug.DrawRay(transform.position, direction, Color.red); // muestra el rayo en el editor
            isFollowing = false; // el enemigo no est� persiguiendo al jugador
            followTime = 0f; // reinicia el tiempo de seguimiento
        }

        // detiene la persecuci�n despu�s de un cierto tiempo
        if (isFollowing && followTime >= 2f)
        {
            isFollowing = false;
            followTime = 0f;
        }

        //OnDrawGizmos();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            panelDed.SetActive(true);
            animator.SetTrigger("Muerto");
            StartCoroutine(Ara�aMata());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    IEnumerator Ara�aMata()
    {
        yield return new WaitForSeconds(4.35f);
        SceneManager.LoadScene(0);
    }
}



