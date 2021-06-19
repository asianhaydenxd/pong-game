using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameObject LeftPaddle;
    public GameObject RightPaddle;

    int direction = -1;

    float longitude = 0.0f;
    float altitude = 0.0f;

    float longitudeSpeed = 4.0f;
    float altitudeSpeed = 0.0f;

    bool clamping = true;

    void Start()
    {
        altitudeSpeed = Random.Range(-1.5f,1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        longitude += longitudeSpeed * direction * Time.deltaTime;
        altitude += altitudeSpeed * Time.deltaTime;

        if (clamping)
        {
        longitude = Mathf.Clamp(longitude, -6.5f, 6.5f);
        }

        altitude = Mathf.Clamp(altitude, -4.75f, 4.75f);

        if (longitude == 6.5f * direction)
        {
            OnCollision();
        }

        if (Mathf.Abs(altitude) == 4.75f) altitudeSpeed = -altitudeSpeed;

        transform.position = new Vector3(longitude, altitude, 0.0f);
    }

    void OnCollision()
    {
        if (direction == -1 & Mathf.Abs(altitude - LeftPaddle.transform.position.y) <= 1.25f)
        {
            direction = -direction;
            altitudeSpeed += (altitude - LeftPaddle.transform.position.y) * 3;
        } 
        else if (Mathf.Abs(altitude - RightPaddle.transform.position.y) <= 1.25f)
        {
            direction = -direction;
            altitudeSpeed += (altitude - RightPaddle.transform.position.y) * 3;
        }
        else
        {
            clamping = false; // Cease longitudinal restrictions
        }

        longitudeSpeed += 0.2f;
    }
}