using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public new AudioSource audio;
    public void Start()
    {
        audio = GetComponent<AudioSource>();

    }
    public void OnPlayButton () 
    {
        StartCoroutine(test(1.3f));
    }

    public void OnQuitButton ()
    {
        Application.Quit();
    }

    public void OnBackToMenuButton () 
    {
        SceneManager.LoadScene(0);
    }

    public void OnVolumeButton ()
    {
        audio.mute = !audio.mute;
    }



    private IEnumerator test(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }
}
