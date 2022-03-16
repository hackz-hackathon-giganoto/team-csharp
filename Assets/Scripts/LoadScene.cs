using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    [SerializeField]
    Main main;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(2);
            main.GoResult();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(0);
        }
    }
}
