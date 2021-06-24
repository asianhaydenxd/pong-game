using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausing : MonoBehaviour
{
    public AudioSource Beep;

    public Animator transition;

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
            Beep.Play();

            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
            GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
        }
    }

    // OnMainMenuPress is called when the Main Menu button is clicked
    public void OnMainMenuPress()
    {
        Beep.Play();
        StartCoroutine("LoadMenu");
    }

    // OnQuitGamePress is called when the Quit Game button is clicked
    public void OnQuitGamePress()
    {
        Beep.Play();
        Application.Quit();
    }

    IEnumerator LoadMenu()
    {   
        // Set up temporary variable for player movement
        float movementSpeedTemp = PlayerMovement.movementSpeed;

        // Stop objects' motion
        PlayerMovement.movementSpeed = 0.0f;

        BallMovement.longitudeSpeed = 0.0f;
        BallMovement.altitudeSpeed = 0.0f;

        // Finally unpause the game and run the animation
        // (objects in the background won't move due to their motion being halted)
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;

        transition.SetTrigger("SlideIn");
        yield return new WaitForSeconds(0.67f);

        // Reset all variables to prepare for when the scene is loaded again

        PlayerMovement.movementSpeed = movementSpeedTemp;

        PlayerMovement.altitude = 0.0f;
        ComputerMovement.altitude = 0.0f;

        BallMovement.longitude = 0.0f;
        BallMovement.altitude = 0.0f;

        BallMovement.longitudeSpeed = 0.0f;
        BallMovement.altitudeSpeed = 0.0f;

        PointSensor.leftScore = 0;
        PointSensor.rightScore = 0;

        SceneManager.LoadScene(0);
    }
}
