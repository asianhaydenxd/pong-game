using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerMovement : MonoBehaviour
{
    float triggerRange; // Paddle accuracy setting constant

    public static float altitude = 0.0f;
    float triggerDistance = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        triggerRange = PlayerPrefs.GetFloat("ComputerAccuracy", 1.5f); // Update from PlayerPrefs
        triggerDistance = Random.Range(0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("VersusBot") != 0)
            MoveByComputer();
        else
            MoveByPlayer();
        
        altitude = Mathf.Clamp(altitude, -4.0f, 4.0f);
        
        transform.position = new Vector3(7.0f, altitude, 0.0f);
    }

    void MoveByComputer()
    {
        if (BallMovement.longitudeSpeed < 0) return;
        if (BallMovement.longitude > transform.position.x) return;

        if (BallMovement.altitude > altitude + triggerDistance)
            altitude += PlayerMovement.movementSpeed * Time.deltaTime;
            
        else if (BallMovement.altitude < altitude - triggerDistance)
            altitude -= PlayerMovement.movementSpeed * Time.deltaTime;
    }

    void MoveByPlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            altitude += PlayerMovement.movementSpeed * Time.deltaTime;

        else if (Input.GetKey(KeyCode.DownArrow))
            altitude -= PlayerMovement.movementSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider trigger)
    {
        triggerDistance = Random.Range(0.0f, triggerRange);
    }
}
