using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public const float ballSpeed = 15.0f; // Ball speed setting constant

    public AudioSource Beep;
    public AudioSource Hit1;
    public AudioSource Hit2;

    public static float longitude = 0.0f;
    public static float altitude = 0.0f;

    public static float longitudeSpeed = ballSpeed;
    public static float altitudeSpeed = 0.0f;

    const float speedIncrement = 0.0f;
    const float altitudeSpeedClamp = 16.0f;

    // Start is called before the first frame update
    void Start()
    {
        altitudeSpeed = Random.Range(-1.5f, 1.5f);
        Invoke("StopWait", 1);
    }

    bool wait = true;

    void StopWait()
    {
        wait = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (wait) return;

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

    void OnTriggerEnter(Collider trigger)
    {
        if (Mathf.Abs(transform.position.x) > Mathf.Abs(trigger.transform.position.x)) return;
        if (!(trigger.name == "Left Paddle" | trigger.name == "Right Paddle")) return;

        Hit1.Play();
        
        longitudeSpeed = -longitudeSpeed;

        if (longitudeSpeed >= 0.0f)
            longitudeSpeed += speedIncrement;
        else
            longitudeSpeed -= speedIncrement;

        altitudeSpeed += 3 * (transform.position.y - trigger.transform.position.y);
        
        altitudeSpeed = Mathf.Clamp(altitudeSpeed, -altitudeSpeedClamp, altitudeSpeedClamp);
    }
}