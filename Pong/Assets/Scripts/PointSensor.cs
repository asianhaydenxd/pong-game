using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSensor : MonoBehaviour
{
    public static int leftScore = 0;
    public static int rightScore = 0;

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

    void OnSensorTrigger()
    {
        BallMovement.longitudeSpeed = 0.0f;
        BallMovement.altitudeSpeed = 0.0f;

        Beep.Play();

        Invoke("ResetScene", 2);
    }

    public Text leftText;
    public Text rightText;

    // Update is called once per frame
    void Update()
    {
        leftText.text = leftScore.ToString();
        rightText.text = rightScore.ToString();
    }

    void ResetScene()
    {
        PlayerMovement.altitude = 0.0f;
        ComputerMovement.altitude = 0.0f;

        BallMovement.longitude = 0.0f;
        BallMovement.altitude = 0.0f;

        BallMovement.longitudeSpeed = 0.0f;
        BallMovement.altitudeSpeed = 0.0f;

        Invoke("DelayBall", 1);
    }

    void DelayBall()
    {
        BallMovement.longitudeSpeed = BallMovement.ballSpeed;
        BallMovement.altitudeSpeed = Random.Range(-1.5f, 1.5f);
    }
}