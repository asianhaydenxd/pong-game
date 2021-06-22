using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerMovement : MonoBehaviour
{
    const float triggerRange = 1.5f; // Paddle accuracy setting constant

    public static float altitude = 0.0f;
    float triggerDistance = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        triggerDistance = Random.Range(0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (BallMovement.longitudeSpeed < 0) return;
        if (BallMovement.longitude > transform.position.x) return;

        if (BallMovement.altitude > altitude + triggerDistance)
            altitude += PlayerMovement.movementSpeed * Time.deltaTime;

        if (BallMovement.altitude < altitude - triggerDistance)
            altitude -= PlayerMovement.movementSpeed * Time.deltaTime;
        
        altitude = Mathf.Clamp(altitude, -4.0f, 4.0f);
        
        transform.position = new Vector3(7.0f, altitude, 0.0f);
    }

    void OnTriggerEnter(Collider trigger)
    {
        triggerDistance = Random.Range(0.0f, triggerRange);
    }
}
