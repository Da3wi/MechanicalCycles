using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 10f; // rango de detección del jugador
    public LayerMask playerLayer; // capa del jugador
    public Transform target; // transform del jugador
    public float speed;
    public GameObject panelDed;
    private bool isFollowing = false; // indica si el enemigo está persiguiendo al jugador
    private float followTime = 0f; // indica cuánto tiempo ha estado persiguiendo al jugador
    public Animator animator;
    public AudioClip spiderSound;
    public AudioSource audioSource;
    private void Update()
    {
        // comprueba si hay algún objeto entre el enemigo y el jugador
        Vector3 direction = target.position - transform.position;
        bool isObstructed = Physics.Linecast(transform.position, target.position, out RaycastHit hit, ~playerLayer);

        if (!isObstructed && direction.magnitude <= detectionRange)
        {
            // si no hay obstáculos y el jugador está dentro del rango de detección, persigue al jugador
            //Debug.DrawRay(transform.position, direction, Color.green); // muestra el rayo en el editor
            Debug.DrawRay(transform.position, transform.forward * detectionRange, Color.yellow); // muestra el rango de visión del enemigo
            // aquí puedes añadir código para perseguir al jugador, por ejemplo:
            audioSource.PlayOneShot(spiderSound);
            transform.LookAt(target); // mira al jugador
            transform.Translate(Vector3.forward * speed * Time.deltaTime); // avanza hacia el jugador
            isFollowing = true; // el enemigo está persiguiendo al jugador
            followTime += Time.deltaTime; // aumenta el tiempo de seguimiento
        }
        else
        {
            // si hay obstáculos o el jugador está fuera del rango de detección, no hace nada
            //Debug.DrawRay(transform.position, direction, Color.red); // muestra el rayo en el editor
            isFollowing = false; // el enemigo no está persiguiendo al jugador
            followTime = 0f; // reinicia el tiempo de seguimiento
        }

        // detiene la persecución después de un cierto tiempo
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
            StartCoroutine(ArañaMata());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    IEnumerator ArañaMata()
    {
        yield return new WaitForSeconds(4.35f);
        SceneManager.LoadScene(0);
    }
}



