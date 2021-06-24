using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSensor : MonoBehaviour
{
    const int goal = 2; // Goal setting constant

    public static int leftScore = 0;
    public static int rightScore = 0;

    public Animator wipe;
    public Animator winSlide;

    void Start()
    {
        GameObject.Find("Transition").GetComponent<Canvas>().enabled = true; // Make transition sprite visible
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.name == "Left Sensor")
        {
            rightScore++;
            OnSensorTrigger();
        }
        else if (trigger.name == "Right Sensor")
        {
            leftScore++;
            OnSensorTrigger();
        }
    }

    public AudioSource Beep;

    public Text labelText;

    void OnSensorTrigger()
    {
        BallMovement.longitudeSpeed = 0.0f;
        BallMovement.altitudeSpeed = 0.0f;

        Beep.Play();

        if (leftScore == goal)
        {
            labelText.text = "Player\nWins";
            StartCoroutine("AnnounceWinner");
        }
        else if (rightScore == goal)
        {
            labelText.text = "Computer\nWins";
            StartCoroutine("AnnounceWinner");
        }
        else
            StartCoroutine("ResetScene");
    }

    public Text leftText;
    public Text rightText;

    // Update is called once per frame
    void Update()
    {
        leftText.text = leftScore.ToString();
        rightText.text = rightScore.ToString();
    }

    IEnumerator ResetScene()
    {
        wipe.SetTrigger("SlideIn");
        yield return new WaitForSeconds(0.67f); // Animation lasts 2/3 (0.67) seconds

        PlayerMovement.altitude = 0.0f;
        ComputerMovement.altitude = 0.0f;

        BallMovement.longitude = 0.0f;
        BallMovement.altitude = 0.0f;

        BallMovement.longitudeSpeed = 0.0f;
        BallMovement.altitudeSpeed = 0.0f;

        wipe.SetTrigger("SlideOut");
        yield return new WaitForSeconds(1.67f); // Animation duration + 1 second delay before restarting

        BallMovement.longitudeSpeed = BallMovement.ballSpeed;
        BallMovement.altitudeSpeed = Random.Range(-1.5f, 1.5f);
    }

    IEnumerator AnnounceWinner()
    {
        winSlide.SetTrigger("Win");
        yield return new WaitForSeconds(2.0f);

        // Loads the main menu using the function from the script Pausing.cs
        GameObject.Find("Pause Menu").GetComponent<Pausing>().StartCoroutine("LoadMenu");
    }
}