using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioSource Beep;

    public Animator wipe;

    void Start()
    {
        GameObject.Find("Transition").GetComponent<Canvas>().enabled = true; // Make transition sprite visible
    }

    public void OnApplyPress()
    {
        StartCoroutine("Exit");
    }

    public void OnCancelPress()
    {
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
