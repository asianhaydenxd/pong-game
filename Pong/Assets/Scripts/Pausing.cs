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

    public void OnMainMenuPress()
    {
        Beep.Play();
        GoToMenu();
    }

    public void OnQuitGamePress()
    {
        Beep.Play();
        Application.Quit();
    }

    public void GoToMenu()
    {
        StartCoroutine("Menu");
    }

    IEnumerator Menu()
    {
        transition.SetTrigger("Exit");
        yield return new WaitForSecondsRealtime(0.75f);

        PlayerMovement.altitude = 0.0f;
        ComputerMovement.altitude = 0.0f;

        BallMovement.longitude = 0.0f;
        BallMovement.altitude = 0.0f;

        BallMovement.longitudeSpeed = BallMovement.ballSpeed;
        BallMovement.altitudeSpeed = Random.Range(-1.5f, 1.5f);

        PointSensor.leftScore = 0;
        PointSensor.rightScore = 0;

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
