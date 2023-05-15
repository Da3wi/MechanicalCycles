using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    public void CargarMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void cargarescena()
    {
        SceneManager.LoadScene(1);
    }

}
