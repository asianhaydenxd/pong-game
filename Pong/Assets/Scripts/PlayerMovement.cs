using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float altitude = 0f;
    const float movementSpeed = 0.02f;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) altitude += movementSpeed;
        if (Input.GetKey(KeyCode.DownArrow)) altitude -= movementSpeed;

        if (altitude > 4) altitude = 4;
        if (altitude < -4) altitude = -4;

        transform.position = new Vector3(-7f, altitude, 0f);
    }
}
