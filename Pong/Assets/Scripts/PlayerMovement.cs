using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float altitude = 0.0f;
    const float movementSpeed = 12.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) altitude += movementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) altitude -= movementSpeed * Time.deltaTime;

        altitude = Mathf.Clamp(altitude, -4.0f, 4.0f);

        transform.position = new Vector3(-7.0f, altitude, 0.0f);
    }
}