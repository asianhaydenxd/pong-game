using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenAnimation : MonoBehaviour
{
    public AudioSource Beep;
    public AudioSource Hit2;

    float longitudeSpeed = 20.0f;
    float altitudeSpeed = 8.0f;

    float longitude;
    float altitude;

    // Start is called before the first frame update
    void Start()
    {
        longitude = Random.Range(-8.387f, 8.387f);
        altitude = Random.Range(-4.5f, 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        longitude += longitudeSpeed * Time.deltaTime;
        altitude += altitudeSpeed * Time.deltaTime;

        longitude = Mathf.Clamp(longitude, -8.387f, 8.387f);
        altitude = Mathf.Clamp(altitude, -4.5f, 4.5f);

        if (Mathf.Abs(longitude) == 8.387f)
        {
            longitudeSpeed = -longitudeSpeed;
            Hit2.Play();
        }

        if (Mathf.Abs(altitude) == 4.5f)
        {
            altitudeSpeed = -altitudeSpeed;
            Hit2.Play();
        }

        transform.position = new Vector3(longitude, altitude, 0.0f);
    }
}
