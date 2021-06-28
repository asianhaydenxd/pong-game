using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioSource Beep;

    public Animator wipe;

    // Get all setting GUIs
    public GameObject ballSpeed;
    public GameObject ballAcceleration;
    public GameObject maxVerticalSpeed;
    public GameObject paddleSpeed;
    public GameObject computerAccuracy;
    public GameObject pointGoal;
    public GameObject versusBot;

    void UpdateGUI()
    {
        ballSpeed.GetComponent<Slider>().value = PlayerPrefs.GetFloat("BallSpeed", 15.0f);
        ballAcceleration.GetComponent<Slider>().value = PlayerPrefs.GetFloat("BallAcceleration", 0.0f);
        maxVerticalSpeed.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MaxVerticalSpeed", 16.0f);
        paddleSpeed.GetComponent<Slider>().value = PlayerPrefs.GetFloat("PaddleSpeed", 12.0f);
        computerAccuracy.GetComponent<Slider>().value = PlayerPrefs.GetFloat("ComputerAccuracy", 1.5f);

        pointGoal.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("PointGoal", 10) - 2;
        versusBot.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt("VersusBot", 1) != 0;
    }

    void Start()
    {
        GameObject.Find("Transition").GetComponent<Canvas>().enabled = true; // Make transition sprite visible
        UpdateGUI();
    }

    public void OnApplyPress()
    {
        PlayerPrefs.SetFloat("BallSpeed", ballSpeed.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("BallAcceleration", ballAcceleration.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("MaxVerticalSpeed", maxVerticalSpeed.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("PaddleSpeed", paddleSpeed.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("ComputerAccuracy", computerAccuracy.GetComponent<Slider>().value);

        PlayerPrefs.SetInt("PointGoal", pointGoal.GetComponent<Dropdown>().value + 2);
        PlayerPrefs.SetInt("VersusBot", versusBot.GetComponent<Toggle>().isOn ? 1 : 0);

        StartCoroutine("Exit");
    }

    public void OnCancelPress()
    {
        StartCoroutine("Exit");
    }

    public void OnRevertPress()
    {
        PlayerPrefs.DeleteAll();
        UpdateGUI();

        StartCoroutine("Exit");
    }

    IEnumerator Exit()
    {
        Beep.Play();

        wipe.SetTrigger("SlideIn");
        yield return new WaitForSeconds(0.67f);

        SceneManager.LoadScene(0);
    }
}
