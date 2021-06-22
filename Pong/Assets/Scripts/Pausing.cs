using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
            
            GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
        }
    }

    public void OnMainMenuPress()
    {
        PlayerMovement.altitude = 0.0f;
        ComputerMovement.altitude = 0.0f;

        BallMovement.longitude = 0.0f;
        BallMovement.altitude = 0.0f;

        BallMovement.longitudeSpeed = 20.0f;
        BallMovement.altitudeSpeed = Random.Range(-1.5f, 1.5f);

        PointSensor.leftScore = 0;
        PointSensor.rightScore = 0;

        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }

    public void OnQuitGamePress()
    {
        Application.Quit();
    }
}
