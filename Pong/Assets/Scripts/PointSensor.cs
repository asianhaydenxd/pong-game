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
            leftScore++;
        else if (trigger.name == "Right Sensor")
            rightScore++;
    }

    public Text leftText;
    public Text rightText;

    // Update is called once per frame
    void Update()
    {
        leftText.text = leftScore.ToString();
        rightText.text = rightScore.ToString();
    }
}