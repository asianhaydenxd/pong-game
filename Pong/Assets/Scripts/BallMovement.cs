using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public static float ballSpeed; // Ball speed setting constant
    float speedIncrement; // Ball acceleration setting constant
    float verticalClamp; // Maximum vertical velocity setting constant

    public AudioSource Beep;
    public AudioSource Hit1;
    public AudioSource Hit2;

    public static float longitude = 0.0f;
    public static float altitude = 0.0f;

    public static float longitudeSpeed = 0.0f;
    public static float altitudeSpeed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Update from PlayerPrefs
        ballSpeed = PlayerPrefs.GetFloat("BallSpeed", 15.0f);
        speedIncrement = PlayerPrefs.GetFloat("BallAcceleration", 0.0f);
        verticalClamp = PlayerPrefs.GetFloat("MaxVerticalSpeed", 16.0f);

        Invoke("ReleaseBall", 1.0f);
    }

    // ReleaseBall is called one second after Start
    void ReleaseBall()
    {
        longitudeSpeed = ballSpeed;
        altitudeSpeed = Random.Range(-1.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        longitude += longitudeSpeed * Time.deltaTime;
        altitude += altitudeSpeed * Time.deltaTime;

        altitude = Mathf.Clamp(altitude, -4.75f, 4.75f);

        if (Mathf.Abs(altitude) == 4.75f)
        {
            altitudeSpeed = -altitudeSpeed;

            Hit2.Play();
        }

        transform.position = new Vector3(longitude, altitude, 0.0f);
    }

    // OnTriggerEnter is called when the ball hits something
    void OnTriggerEnter(Collider trigger)
    {
        // Make sure ball is hitting a paddle and is in front of the paddles (guard clauses)
        if (Mathf.Abs(transform.position.x) > Mathf.Abs(trigger.transform.position.x)) return;
        if (!(trigger.name == "Left Paddle" | trigger.name == "Right Paddle")) return;

        Hit1.Play();
        
        // Reverse ball direction and adjust the vertical speed
        longitudeSpeed = -longitudeSpeed;
        longitudeSpeed += speedIncrement * Mathf.Sign(longitudeSpeed);
        altitudeSpeed += 3 * (transform.position.y - trigger.transform.position.y);
        altitudeSpeed = Mathf.Clamp(altitudeSpeed, -verticalClamp, verticalClamp);
    }
}