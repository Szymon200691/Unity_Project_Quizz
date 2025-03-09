using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnTimer : MonoBehaviour
{
    public float maxIdleTime = 10f; 
    private float timeToReturn;

    private void Start()
    {
        timeToReturn = maxIdleTime;
    }

    //Po czasie wraca do menu g³ównego
    private void Update()
    {
        timeToReturn -= Time.deltaTime;

        if (timeToReturn <= 0)
        {
            SceneManager.LoadScene("Splash_View", LoadSceneMode.Single);
        }

        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            timeToReturn = maxIdleTime;
        }
    }
}
