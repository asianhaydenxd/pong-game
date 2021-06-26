using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource Beep;

    public Animator wipe;
    
    void Start()
    {
        // Make transition sprite visible
        GameObject.Find("Transition").GetComponent<Canvas>().enabled = true;
    }

    public void OnStartButtonPress()
    {
        StartCoroutine("PressStart");
    }

    public void OnSettingsButtonPress()
    {
        StartCoroutine("PressSettings");
    }

    public void OnQuitButtonPress()
    {
        Application.Quit();
    }

    IEnumerator PressStart()
    {
        Beep.Play();
        
        wipe.SetTrigger("SlideIn");
        yield return new WaitForSeconds(0.67f);

        SceneManager.LoadScene(1);
    }

    IEnumerator PressSettings()
    {
        Beep.Play();
        
        wipe.SetTrigger("SlideIn");
        yield return new WaitForSeconds(0.67f);

        SceneManager.LoadScene(2);
    }
}