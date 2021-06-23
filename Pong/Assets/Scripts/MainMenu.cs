using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource Beep;
    public Animator wipeIn;
    
    void Start()
    {
        GameObject.Find("Transition").GetComponent<Canvas>().enabled = true;
    }

    public void OnStartButtonPress()
    {
        StartCoroutine("PressStart");
    }

    public void OnQuitButtonPress()
    {
        Application.Quit();
    }

    IEnumerator PressStart()
    {
        Beep.Play();
        wipeIn.SetTrigger("Exit");
        yield return new WaitForSeconds(0.75f);

        SceneManager.LoadScene(1);
    }
}