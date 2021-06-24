using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float altitude = 0.0f;
    public static float movementSpeed = 12.0f;

    // Update is called once per frame
    void Update()
    {
        // Move the paddle and keep on screen
        altitude += movementSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        altitude = Mathf.Clamp(altitude, -4.0f, 4.0f);

        // Update the paddle's position
        transform.position = new Vector3(-7.0f, altitude, 0.0f);
    }
}
